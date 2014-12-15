using System;
using NServiceBus.Saga;

namespace NServiceBus.SagaExample.Sagas.Arears
{
    public class ArearsSagaData : ContainSagaData
    {
        public DateTime? PaymentTakenAt { get; set; }
        
        public DateTime AgreementCreatedAt { get; set; }

        public int MonthsInArears { get; set; }
    }
}