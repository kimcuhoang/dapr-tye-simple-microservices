using System;
using System.Threading.Tasks;

namespace SimpleStore.Domain.Models
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(IDomainEvent @event);
    }
}
