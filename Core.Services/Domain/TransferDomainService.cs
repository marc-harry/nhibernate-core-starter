using Core.Domain;
using Core.Events.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Domain
{
    public class TransferDomainService : ITransferDomainService
    {
        public TransferRegisteredEvent Create(Debit debit, Credit credit)
        {
            debit.MustNotBeNull();
            credit.MustNotBeNull();

            debit.Account.MustNotBe(credit.Account);

            return new TransferRegisteredEvent
            {
                EntityId = Guid.NewGuid(),
                Amount = debit.Value,
                DebitAccountNo = debit.Account.AccountNumber,
                CreditAccountNo = credit.Account.AccountNumber
            };
        }
    }
}
