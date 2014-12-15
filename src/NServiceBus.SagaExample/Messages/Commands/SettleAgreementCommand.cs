using System;

namespace NServiceBus.SagaExample.Messages.Commands
{
    public class SettleAgreementCommand : ICommand
    {
        public Guid AgreementId { get; set; }
    }
}
