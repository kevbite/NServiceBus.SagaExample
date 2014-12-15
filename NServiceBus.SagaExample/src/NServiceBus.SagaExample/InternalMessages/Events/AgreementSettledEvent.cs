using System;

namespace NServiceBus.SagaExample.InternalMessages.Events
{
    public class AgreementSettledEvent : IEvent
    {
        public Guid AgreementId { get; set; }
    }
}
