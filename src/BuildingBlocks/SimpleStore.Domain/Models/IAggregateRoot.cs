using System.Collections.Generic;

namespace SimpleStore.Domain.Models
{
    public interface IAggregateRoot
    {
        void AddUncommittedEvent(IDomainEvent @event);
        IEnumerable<IDomainEvent> UncommittedEvents { get; }
        void ClearUncommittedEvents();
    }
}
