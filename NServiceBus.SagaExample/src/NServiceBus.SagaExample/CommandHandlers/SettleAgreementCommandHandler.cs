using System;
using NServiceBus.SagaExample.InternalMessages.Events;
using NServiceBus.SagaExample.Messages.Commands;

namespace NServiceBus.SagaExample.CommandHandlers
{
    public class SettleAgreementCommandHandler : IHandleMessages<SettleAgreementCommand>
    {
        private readonly IBus _bus;

        public SettleAgreementCommandHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Handle(SettleAgreementCommand message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("** Agreement Settled with Id {0} **", message.AgreementId);
            Console.ResetColor();

            _bus.Publish(new AgreementSettledEvent { AgreementId = message.AgreementId });
        }
    }
}
