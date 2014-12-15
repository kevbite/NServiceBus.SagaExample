using System;

namespace NServiceBus.SagaExample.InternalMessages.Events
{
    public class AgreementCreatedEvent: IEvent
    {
        public Guid AgreementId { get; set; }
    }
}