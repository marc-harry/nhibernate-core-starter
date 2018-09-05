using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Events.Events
{
    public class TransferRegisteredEvent : BaseEvent
    {
        public Guid EntityId { get; set; }
        public decimal Amount { get; set; }
        public string DebitAccountNo { get; set; }
        public string CreditAccountNo { get; set; }
    }
}
