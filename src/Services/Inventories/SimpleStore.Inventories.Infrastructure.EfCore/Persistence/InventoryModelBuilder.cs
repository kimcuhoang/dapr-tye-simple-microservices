using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Infrastructure.EfCore.Persistence;

namespace SimpleStore.Inventories.Infrastructure.EfCore.Persistence
{
    public class InventoryModelBuilder : ICustomModelBuilder
    {
        #region Implementation of ICustomModelBuilder

        public void Build(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        #endregion
    }
}
