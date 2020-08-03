using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace SimpleStore.Domain.Models
{
    public abstract class AggregateRoot<TIdentity> : EntityBase<TIdentity>, IAggregateRoot
                    where TIdentity : IdentityBase
    {
        private readonly IDictionary<Type, Action<object>> _handlers = new ConcurrentDictionary<Type, Action<object>>();
        private readonly List<IDomainEvent> _uncommittedEvents = new List<IDomainEvent>();

        protected AggregateRoot(TIdentity id) : base(id) { }
       
        protected AggregateRoot() { }

        #region Implementation of IAggregateRoot

        public void AddUncommittedEvent(IDomainEvent @event) => this._uncommittedEvents.Add(@event);

        public IEnumerable<IDomainEvent> UncommittedEvents => this._uncommittedEvents;

        public void ClearUncommittedEvents() => this._uncommittedEvents.Clear();

        #endregion
    }
}
