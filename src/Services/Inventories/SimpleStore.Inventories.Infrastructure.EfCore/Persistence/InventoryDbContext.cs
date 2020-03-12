using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Infrastructure.EfCore.Persistence;

namespace SimpleStore.Inventories.Infrastructure.EfCore.Persistence
{
    public class InventoryDbContext : ApplicationDbContextBase
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> dbContextOptions) : base(dbContextOptions) { }

        protected override Assembly CurrentAssembly => Assembly.GetExecutingAssembly();
    }
}
