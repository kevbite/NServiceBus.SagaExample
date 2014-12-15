using System;
using NServiceBus.SagaExample.InternalMessages.Events;
using NServiceBus.SagaExample.Messages.Commands;

namespace NServiceBus.SagaExample.CommandHandlers
{
    public class CreateAgreementCommandHandler : IHandleMessages<CreateAgreementCommand>
    {
        private readonly IBus _bus;

        public CreateAgreementCommandHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Handle(CreateAgreementCommand message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("** Creating Agreement with Id {0} **", message.AgreementId);
            Console.ResetColor();

            _bus.Publish(new AgreementCreatedEvent{AgreementId = message.AgreementId});
        }
    }
}
