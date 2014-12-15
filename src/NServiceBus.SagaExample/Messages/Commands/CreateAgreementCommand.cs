using System;

namespace NServiceBus.SagaExample.Messages.Commands
{
    public class CreateAgreementCommand : ICommand
    {
        public Guid AgreementId { get; set; }
    }
}
