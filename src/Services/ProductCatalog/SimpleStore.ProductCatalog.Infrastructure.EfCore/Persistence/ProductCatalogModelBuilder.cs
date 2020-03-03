using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Infrastructure.EfCore;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Persistence
{
    public class ProductCatalogModelBuilder : ICustomModelBuilder
    {
        #region Implementation of ICustomModelBuilder

        public void Build(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        #endregion
    }
}
