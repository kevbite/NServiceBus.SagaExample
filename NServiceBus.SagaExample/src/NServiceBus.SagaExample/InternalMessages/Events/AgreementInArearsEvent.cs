using System;

namespace NServiceBus.SagaExample.InternalMessages.Events
{
    public class AgreementInArearsEvent : IEvent
    {
        public Guid AgreementId { get; set; }
        
        public int MonthsInArears { get; set; }
    }
}
