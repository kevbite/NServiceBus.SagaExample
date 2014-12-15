using System;
using NServiceBus.Saga;

namespace NServiceBus.SagaExample.Sagas.Arears
{
    public class ArearsSagaData : ContainSagaData
    {
        [Unique]
        public Guid AgreementId { get; set; }

        public DateTime? PaymentTakenAt { get; set; }
        
        public DateTime AgreementCreatedAt { get; set; }

        public int MonthsInArears { get; set; }
    }
}