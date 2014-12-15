namespace NServiceBus.SagaExample
{
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UsePersistence<InMemoryPersistence>();

            configuration.UseTransport<RabbitMQTransport>();
        }
    }
}
