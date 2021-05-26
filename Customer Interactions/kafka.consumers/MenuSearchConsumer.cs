using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using kafka.consumers.ConsumedModels;
using kafka.consumers.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nest;

namespace kafka.consumers
{
    public class MenuSearchConsumer : BackgroundService
    {
        private readonly IElasticClient _client;
        private readonly IDictionary<string, string> _kafkaConfiguration;
        private IServiceScope _scope;

        public MenuSearchConsumer(IServiceProvider provider, IConfiguration configuration)
        {
            _scope = provider.CreateScope();

            _client = _scope.ServiceProvider.GetService<IElasticClient>();
            _kafkaConfiguration = new Dictionary<string, string>();

            configuration
                .GetSection("kafka:consumer")
                .Bind(_kafkaConfiguration);

            _kafkaConfiguration["group.id"] = $"{_kafkaConfiguration["group.id"]}.search";
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var consumer = new ConsumerBuilder<Guid, Menu>(_kafkaConfiguration)
                .SetKeyDeserializer(new GuidKeyDeserializer())
                .SetValueDeserializer(new JsonValueDeserializer<Menu>())
                .Build();

            consumer.Subscribe("menus");

            await Task.Run(async () =>
            {
                do
                {
                    var result = consumer.Consume(cancellationToken);

                    if (result != null)
                    {
                        var items = from c in result.Message.Value.Categories
                                    from i in c.Items
                                    select new SearchMenuItem
                                    {
                                        Id = i.Id,
                                        Name = i.Name,
                                        Description = i.Description
                                    };

                        foreach (var item in items)
                        {
                            await _client.IndexAsync(
                                new IndexRequest<SearchMenuItem>("menu-items", item.Id)
                                { Document = item }, cancellationToken);
                        }

                        consumer.Commit(result);
                    }
                } while (!cancellationToken.IsCancellationRequested);
            }, cancellationToken);
        }
    }

    public class SearchMenuItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}