using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Account : IEquatable<Account>
    {
        public string AccountNumber { get; }
        public string Sortcode { get; }

        public Account(string accountNumber, string sortcode)
        {
            AccountNumber = accountNumber;
            Sortcode = sortcode;
        }

        public bool Equals(Account other) => other != null && AccountNumber == other.AccountNumber && Sortcode == other.Sortcode;
    }
}
