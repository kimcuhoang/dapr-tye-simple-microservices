namespace SimpleStore.Domain.Models
{
    public abstract class AggregateRoot : EntityBase
    {
        protected AggregateRoot(IdentityBase id) : base(id)
        {
        }
        protected AggregateRoot() { }
    }
}
