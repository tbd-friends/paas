using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mongo.repository;
using MongoDB.Driver;
using static System.Console;

namespace kafka.consumers
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
                new MongoRepository(p.GetService<IMongoClient>(), "website"));
            services.AddSingleton<IConfiguration>(configuration);
            services.AddScoped<MenuConsumer>();

            var source = new CancellationTokenSource();

            var provider = services.BuildServiceProvider();

            var consumer = provider.GetService<MenuConsumer>();

            await consumer.StartAsync(source.Token);

            try
            {
                WriteLine("Press any key to exit");

                await Task.Run(ReadLine, source.Token);
            }
            finally
            {
                WriteLine("Completed");
            }
        }
    }
}
