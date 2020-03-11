using Microsoft.EntityFrameworkCore;

namespace SimpleStore.Infrastructure.EfCore.Persistence
{
    public interface ICustomModelBuilder
    {
        void Build(ModelBuilder modelBuilder);
    }
}
