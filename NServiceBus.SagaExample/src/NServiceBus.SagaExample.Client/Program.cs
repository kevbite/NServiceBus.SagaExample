namespace NServiceBus.SagaExample.Client
{
    class Program
    {
        private static void Main(string[] args)
        {
            var configuration = new BusConfiguration();

            configuration.UsePersistence<InMemoryPersistence>();

            configuration.UseTransport<RabbitMQTransport>();

            using (var bus = Bus.CreateSendOnly(configuration))
            {
                var sagaExampleClient = new SagaExampleClient(bus);

                sagaExampleClient.Run();
            }
        }
    }
}
