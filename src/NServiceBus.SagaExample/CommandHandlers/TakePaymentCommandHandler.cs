using System;
using NServiceBus.SagaExample.InternalMessages.Events;
using NServiceBus.SagaExample.Messages.Commands;

namespace NServiceBus.SagaExample.CommandHandlers
{
    public class TakePaymentCommandHandler : IHandleMessages<TakePaymentCommand>
    {
        private readonly IBus _bus;

        public TakePaymentCommandHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Handle(TakePaymentCommand message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("** Taking Payment for Agreement {0} **", message.AgreementId);
            Console.ResetColor();

            _bus.Publish(new PaymentTakenEvent{AgreementId = message.AgreementId});
        }
    }
}
