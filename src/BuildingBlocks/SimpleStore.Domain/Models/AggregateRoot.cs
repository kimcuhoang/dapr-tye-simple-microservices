using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace SimpleStore.Domain.Models
{
    public abstract class AggregateRoot : EntityBase
    {
        private readonly IDictionary<Type, Action<object>> _handlers = new ConcurrentDictionary<Type, Action<object>>();
        private readonly List<IDomainEvent> _uncommittedEvents = new List<IDomainEvent>();

        public IEnumerable<IDomainEvent> UncommittedEvents => this._uncommittedEvents;

        protected AggregateRoot(IdentityBase id) : base(id)
        {
        }
        protected AggregateRoot() { }

        public void AddUncommittedEvent(IDomainEvent @event)
        {
            this._uncommittedEvents.Add(@event);
        }

        public void ClearUncommittedEvents() => this._uncommittedEvents.Clear();
    }
}
