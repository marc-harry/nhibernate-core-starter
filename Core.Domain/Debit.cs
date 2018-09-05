using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Debit
    {
        public decimal Value { get; }
        public Account Account { get; }

        public Debit(decimal value, Account account)
        {
            Value = value;
            Account = account;
            value.Must(v => v >= 0);
            account.MustNotBeNull();
        }
    }
}
