using System;
using System.Threading.Tasks;
using Gamer.Events;
using MassTransit;

namespace Gamer.Marketing.Loyalty.Consumers
{
    public class AccountRegisteredConsumer : IConsumer<AccountRegistered>
    {
        public Task Consume(ConsumeContext<AccountRegistered> context)
        {
            Console.WriteLine(
                $"Customer {context.Message.Id} was registered with {context.Message.Surname} ({context.Message.Email})");

            return Task.CompletedTask;
        }
    }
}