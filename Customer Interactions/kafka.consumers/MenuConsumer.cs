using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using kafka.consumers.ConsumedModels;
using kafka.consumers.Infrastructure;
using Microsoft.Extensions.Configuration;
using mongo.repository;
using StorageMenu = interactions.models.Menu;

namespace kafka.consumers
{
    public class MenuConsumer
    {
        private readonly IRepository _repository;
        private readonly IDictionary<string, string> _kafkaConfiguration;

        public MenuConsumer(IRepository repository,
            IConfiguration configuration)
        {
            _repository = repository;

            _kafkaConfiguration = new Dictionary<string, string>();

            configuration
                .GetSection("kafka:consumer")
                .Bind(_kafkaConfiguration);
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var consumer = new ConsumerBuilder<Guid, Menu>(_kafkaConfiguration)
                .SetKeyDeserializer(new GuidKeyDeserializer())
                .SetValueDeserializer(new JsonValueDeserializer<Menu>())
                .Build();

            consumer.Subscribe("menus");

            do
            {
                var result = consumer.Consume(cancellationToken);

                if (result != null)
                {
                    var existing =
                        (await _repository.Query<StorageMenu>("menus", m => m.SourceMenuId == result.Message.Key)
                        ).SingleOrDefault();

                    if (existing != null)
                    {
                        var replacement = result.Message.Value.AsStorage();

                        replacement.Id = existing.Id;

                        await _repository.Replace(replacement, m => m.SourceMenuId == result.Message.Key, "menus");
                    }
                    else
                    {
                        await _repository.Add(result.Message.Value.AsStorage(), "menus");
                    }

                    consumer.Commit(result);
                }
            } while (!cancellationToken.IsCancellationRequested);
        }
    }

}