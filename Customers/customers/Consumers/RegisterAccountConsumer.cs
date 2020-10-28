using System;
using System.Threading.Tasks;
using commands;
using MassTransit;

namespace customers.Consumers
{
    public class RegisterAccountConsumer : IConsumer<RegisterAccount>
    {
        public Task Consume(ConsumeContext<RegisterAccount> context)
        {
            Console.WriteLine($"{context.Message.FirstName} {context.Message.Surname} ({context.Message.Email})");

            return Task.CompletedTask;
        }
    }
}