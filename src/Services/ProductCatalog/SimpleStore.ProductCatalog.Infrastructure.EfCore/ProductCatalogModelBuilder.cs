using Microsoft.EntityFrameworkCore;
using SimpleStore.Infrastructure.EfCore;
using System.Reflection;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore
{
    public class ProductCatalogModelBuilder : ICustomModelBuilder
    {
        #region Implementation of ICustomModelBuilder

        public void Build(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        #endregion
    }
}
