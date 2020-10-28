using System;
using System.Threading.Tasks;
using commands;
using customers.Infrastructure;
using customers.Infrastructure.Models;
using MassTransit;

namespace customers.Consumers
{
    public class RegisterAccountConsumer : IConsumer<RegisterAccount>
    {
        private readonly IRepository _repository;

        public RegisterAccountConsumer(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<RegisterAccount> context)
        {
            Console.WriteLine($"{context.Message.FirstName} {context.Message.Surname} ({context.Message.Email})");

            await _repository.Add(new Customer
            {
                FirstName = context.Message.FirstName,
                Surname = context.Message.Surname,
                Email = context.Message.Email
            }, "customers");
        }
    }
}