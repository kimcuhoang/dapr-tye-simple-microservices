using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Models
{
    public interface IAggregateRoot
    {
        IEnumerable<IDomainEvent> UncommittedEvents { get; }
        void ClearUncommittedEvents();
    }
}
