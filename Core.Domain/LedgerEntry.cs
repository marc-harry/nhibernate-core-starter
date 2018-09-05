using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class LedgerEntry
    {
        public Debit Debit { get; private set; }
        public Credit Credit { get; private set; }

        public LedgerEntry(Debit debit, Credit credit)
        {
            Debit = debit;
            Credit = credit;
        }
    }
}
