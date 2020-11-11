using System;
using System.Threading;
using System.Threading.Tasks;
using Gamer.Customer.Customers.Consumers;
using Gamer.Customer.Customers.Consumers.Definitions;
using Gamer.Customer.Customers.Infrastructure;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mongo.repository;
using MongoDB.Driver;

namespace Gamer.Customer.Customers
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
            services.AddScoped<IRepository, MongoRepository>(p =>
                new MongoRepository(p.GetService<IMongoClient>(), "customers-service"));

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
