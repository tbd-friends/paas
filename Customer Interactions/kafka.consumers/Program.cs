using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using mongo.repository;
using MongoDB.Driver;
using Nest;
using static System.Console;

namespace kafka.consumers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder()
                .ConfigureServices(ConfigureServices)
                .Build()
                .RunAsync();
        }

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddSingleton<IMongoClient>(_ =>
                new MongoClient(context.Configuration.GetConnectionString("mongo-db")));
            services.AddScoped<IRepository, MongoRepository>(p =>
                new MongoRepository(p.GetService<IMongoClient>(), "website"));
            services.AddSingleton<IElasticClient>(_ =>
                new ElasticClient(new Uri("http://localhost:9200")));

            services.AddHostedService<MenuConsumer>();
            services.AddHostedService<MenuSearchConsumer>();
        }
    }
}
