using System;
using System.Threading;
using System.Threading.Tasks;
using customers.Consumers;
using MassTransit;

namespace customers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.ReceiveEndpoint("register-account", e =>
                {
                    e.Consumer<RegisterAccountConsumer>();
                });
            });

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
