using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Events.Events
{
    public abstract class BaseEvent
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
