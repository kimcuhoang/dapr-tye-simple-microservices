using Microsoft.EntityFrameworkCore;

namespace SimpleStore.Infrastructure.EfCore
{
    public interface ICustomModelBuilder
    {
        void Build(ModelBuilder modelBuilder);
    }
}
