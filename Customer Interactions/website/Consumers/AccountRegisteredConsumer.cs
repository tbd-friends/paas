using System.Threading.Tasks;
using Gamer.Customer.Website.Infrastructure;
using Gamer.Customer.Website.Infrastructure.Model;
using Gamer.Events;
using MassTransit;

namespace Gamer.Customer.Website.Consumers
{
    public class AccountRegisteredConsumer : IConsumer<AccountRegistered>
    {
        private readonly IRepository _repository;

        public AccountRegisteredConsumer(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<AccountRegistered> context)
        {
            var customer = new CustomerAccount
            {
                FirstName = context.Message.FirstName,
                Surname = context.Message.Surname,
                Email = context.Message.Email,
                IsVerified = false
            };

            await _repository.Add(customer, "customers");
        }
    }
}