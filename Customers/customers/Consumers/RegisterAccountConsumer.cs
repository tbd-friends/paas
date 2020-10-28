using System;
using System.Threading.Tasks;
using commands;
using customers.Infrastructure;
using customers.Infrastructure.Models;
using events;
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

            var customer = new Customer
            {
                FirstName = context.Message.FirstName,
                Surname = context.Message.Surname,
                Email = context.Message.Email
            };

            await _repository.Add(customer, "customers");

            await context.Publish(new AccountRegistered
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                Surname = customer.Surname,
                Email = customer.Email
            });
        }
    }
}