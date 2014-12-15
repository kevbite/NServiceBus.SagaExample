using System;

namespace NServiceBus.SagaExample.InternalMessages.Events
{
    public class PaymentTakenEvent : IEvent
    {
        public Guid AgreementId { get; set; }
    }
}