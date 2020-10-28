using System;
using System.Threading;
using System.Threading.Tasks;
using customers.Consumers;
using customers.Consumers.Definitions;
using customers.Infrastructure;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace customers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var services = new ServiceCollection();

            services.AddSingleton<IMongoClient>(provider =>
                new MongoClient(configuration.GetConnectionString("mongo-db")));
            services.AddScoped<IRepository, MongoRepository>();

            services.AddMassTransit(x =>
            {
                x.AddConsumer<RegisterAccountConsumer>(typeof(RegisterAccountConsumerDefinition));

                x.SetKebabCaseEndpointNameFormatter();

                x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));
            });

            var provider = services.BuildServiceProvider();

            var busControl = provider.GetRequiredService<IBusControl>();

            var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            await busControl.StartAsync(source.Token);

            try
            {
                Console.WriteLine("Press enter to exit");

                await Task.Run(Console.ReadLine, source.Token);
            }
            finally
            {
                await busControl.StopAsync(source.Token);
            }
        }
    }
}
