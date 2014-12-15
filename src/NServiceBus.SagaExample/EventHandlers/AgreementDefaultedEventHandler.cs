using System;
using NServiceBus.SagaExample.InternalMessages.Events;

namespace NServiceBus.SagaExample.EventHandlers
{
    public class AgreementDefaultedEventHandler : IHandleMessages<AgreementDefaultedEvent>
    {
        public void Handle(AgreementDefaultedEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("** Agreement Defaulted {0} **", message.AgreementId);
            Console.ResetColor();
        }
    }
}
