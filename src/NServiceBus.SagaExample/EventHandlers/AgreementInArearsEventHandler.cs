using System;
using NServiceBus.SagaExample.InternalMessages.Events;

namespace NServiceBus.SagaExample.EventHandlers
{
    public class AgreementInArearsEventHandler : IHandleMessages<AgreementInArearsEvent>
    {
        public void Handle(AgreementInArearsEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("** Agreement In Arears by {0} months, {1} **", message.MonthsInArears, message.AgreementId);
            Console.ResetColor();
        }
    }
}
