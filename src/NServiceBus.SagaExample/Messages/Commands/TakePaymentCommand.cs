using System;

namespace NServiceBus.SagaExample.Messages.Commands
{
    public class TakePaymentCommand : ICommand
    {
        public Guid AgreementId { get; set; }
    }
}
