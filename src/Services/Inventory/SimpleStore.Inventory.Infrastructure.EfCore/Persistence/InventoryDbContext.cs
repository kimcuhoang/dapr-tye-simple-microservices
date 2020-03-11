using Microsoft.EntityFrameworkCore;
using SimpleStore.Infrastructure.EfCore.Persistence;
using System.Reflection;

namespace SimpleStore.Inventory.Infrastructure.EfCore.Persistence
{
    public class InventoryDbContext : ApplicationDbContextBase
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> dbContextOptions) : base(dbContextOptions) { }

        protected override Assembly CurrentAssembly => Assembly.GetExecutingAssembly();
    }
}
