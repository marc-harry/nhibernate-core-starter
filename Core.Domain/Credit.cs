using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Credit
    {
        public decimal Value { get; }
        public Account Account { get; }

        public Credit(decimal value, Account account)
        {
            value.Must(v => v >= 0);//business rule
            account.MustNotBeNull();//ensure VO is valid            
            Value = value;
            Account = account;
        }
    }
}
