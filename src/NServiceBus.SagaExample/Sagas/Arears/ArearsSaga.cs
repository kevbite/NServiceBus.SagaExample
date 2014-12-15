using System;
using NServiceBus.Saga;
using NServiceBus.SagaExample.InternalMessages.Events;

namespace NServiceBus.SagaExample.Sagas.Arears
{
    public partial class ArearsSaga : Saga<ArearsSagaData>,
                                IAmStartedByMessages<AgreementCreatedEvent>,
                                IHandleMessages<PaymentTakenEvent>,
                                IHandleMessages<AgreementSettledEvent>,
                                IHandleTimeouts<ArearsSaga.ArearsOneMonthTimeout>
    {
        private readonly IBus _bus;

        public ArearsSaga(IBus bus)
        {
            _bus = bus;
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<ArearsSagaData> mapper)
        {
            mapper.ConfigureMapping<AgreementCreatedEvent>(x => x.AgreementId)
                .ToSaga(x => x.AgreementId);

            mapper.ConfigureMapping<PaymentTakenEvent>(x => x.AgreementId)
                .ToSaga(x => x.AgreementId);

            mapper.ConfigureMapping<AgreementSettledEvent>(x => x.AgreementId)
                .ToSaga(x => x.AgreementId);
        }

        public void Handle(AgreementCreatedEvent message)
        {
            Data.AgreementId = message.AgreementId;
            Data.AgreementCreatedAt = DateTime.UtcNow;

            RequestTimeout<ArearsOneMonthTimeout>(TimeSpan.FromSeconds(5));
        }
        
        public void Handle(PaymentTakenEvent message)
        {
            Data.PaymentTakenAt = DateTime.UtcNow;
            Data.MonthsInArears = 0;

            RequestTimeout<ArearsOneMonthTimeout>(TimeSpan.FromSeconds(5));
        }
        
        public void Timeout(ArearsOneMonthTimeout state)
        {
            if (Data.MonthsInArears >= 12)
            {
                _bus.Publish(new AgreementDefaultedEvent {AgreementId = Data.AgreementId});

                MarkAsComplete();
            }
            else
            {
                Data.MonthsInArears++;

                _bus.Publish(new AgreementInArearsEvent
                {
                    AgreementId = Data.AgreementId,
                    MonthsInArears = Data.MonthsInArears
                });
                
                RequestTimeout<ArearsOneMonthTimeout>(TimeSpan.FromSeconds(5));
            }

        }

        public void Handle(AgreementSettledEvent message)
        {
            MarkAsComplete();           
        }
    }
}
