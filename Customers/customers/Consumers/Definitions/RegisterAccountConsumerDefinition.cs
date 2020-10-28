using MassTransit;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;

namespace customers.Consumers.Definitions
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