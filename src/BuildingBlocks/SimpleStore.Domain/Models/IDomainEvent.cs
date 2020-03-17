using System;

namespace SimpleStore.Domain.Models
{
    public interface IDomainEvent
    {
        DateTime CreatedOn { get; }
    }
}
