using MassTransit.Definition;

namespace Gamer.Customer.Customers.Consumers.Definitions
{
    public class RegisterAccountConsumerDefinition : ConsumerDefinition<RegisterAccountConsumer>
    {
        public RegisterAccountConsumerDefinition()
        {
            EndpointName = "register-account";

            ConcurrentMessageLimit = 8;
        }
    }
}