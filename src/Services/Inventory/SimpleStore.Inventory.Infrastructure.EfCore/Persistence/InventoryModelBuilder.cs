using Microsoft.EntityFrameworkCore;
using SimpleStore.Infrastructure.EfCore.Persistence;
using System.Reflection;

namespace SimpleStore.Inventory.Infrastructure.EfCore.Persistence
{
    public class InventoryModelBuilder : ICustomModelBuilder
    {
        #region Implementation of ICustomModelBuilder

        public void Build(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        #endregion
    }
}
