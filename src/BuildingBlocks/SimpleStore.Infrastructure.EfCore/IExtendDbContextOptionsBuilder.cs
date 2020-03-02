using Microsoft.EntityFrameworkCore;

namespace SimpleStore.Infrastructure.EfCore
{
    public interface IExtendDbContextOptionsBuilder
    {
        DbContextOptionsBuilder Extend(DbContextOptionsBuilder optionsBuilder, IConnectionStringFactory connectionStringFactory, string assemblyName = null);
    }
}
