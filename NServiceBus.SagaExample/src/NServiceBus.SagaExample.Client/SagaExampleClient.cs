using System;
using NServiceBus.SagaExample.Messages.Commands;

namespace NServiceBus.SagaExample.Client
{
    public class SagaExampleClient
    {
        private readonly ISendOnlyBus _bus;

        public SagaExampleClient(ISendOnlyBus bus)
        {
            _bus = bus;
        }

        public void Run()
        {
            ConsoleKey? key = null;
            Guid? agreementId = null;

            WriteWelcomeMessage();

            do
            {
                agreementId = ProcessKey(key, agreementId);

                key = PromptUser(agreementId);

                Console.WriteLine();
            } while (key != ConsoleKey.Q);
        }

        private Guid? ProcessKey(ConsoleKey? key, Guid? agreementId)
        {
            if (key == ConsoleKey.C)
            {
                agreementId = CreateAgreement();
            }
            else if (agreementId != null)
            {
                if (key == ConsoleKey.P)
                {
                    TakePayment(agreementId.Value);
                }
                else if (key == ConsoleKey.S)
                {
                    SettleAgreement(agreementId.Value);
                }
            }

            return agreementId;
        }

        private static void WriteWelcomeMessage()
        {
            Console.WriteLine("Welcome to SagaExampleClient");
            Console.WriteLine("============================");
            Console.WriteLine("Press C to Create an Agreement");
            Console.WriteLine("Press P to Take a Payment");
            Console.WriteLine("Press S to Settle the Agreement");
        }

        private static ConsoleKey? PromptUser(Guid? agreementId)
        {
            Console.WriteLine();
            var promptText = BuildPromptText(agreementId);
            Console.Write("{0}>", promptText);

            var key = Console.ReadKey().Key;

            return key;
        }

        private static string BuildPromptText(Guid? agreementId)
        {
            var promptText = "SagaExampleClient";

            if (agreementId.HasValue)
            {
                promptText += ":" + agreementId;
            }

            return promptText;
        }

        private void SettleAgreement(Guid agreementId)
        {
            var command = new SettleAgreementCommand() { AgreementId = agreementId };

            Log(string.Format("Settling Agreement {0}", agreementId));
            _bus.Send(command);
        }

        private void TakePayment(Guid agreementId)
        {
            var command = new TakePaymentCommand() { AgreementId = agreementId };

            Log(string.Format("Sending Take Payment Command for {0}", agreementId));
            _bus.Send(command);
        }

        private Guid CreateAgreement()
        {
            var agreementId = Guid.NewGuid();
            var command = new CreateAgreementCommand() {AgreementId = agreementId};

            Log(string.Format("Sending Create Agreement Command, {0}", agreementId));
            _bus.Send(command);

            return agreementId;
        }

        private void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}