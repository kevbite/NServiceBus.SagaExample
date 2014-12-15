using System;

namespace NServiceBus.SagaExample.InternalMessages.Events
{
    public class AgreementDefaultedEvent : IEvent
    {
        public Guid AgreementId { get; set; }
    }
}
