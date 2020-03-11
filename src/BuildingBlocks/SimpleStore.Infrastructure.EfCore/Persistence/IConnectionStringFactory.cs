namespace SimpleStore.Infrastructure.EfCore.Persistence
{
    public interface IConnectionStringFactory
    {
        string Create();
    }
}
