using SimpleStore.Infrastructure.EfCore;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore
{
    public class ProductCatalogDbContext : ApplicationDbContextBase
    {
        public ProductCatalogDbContext(DbContextOptions<ProductCatalogDbContext> dbContextOptions) : base(dbContextOptions) { }

        protected override Assembly CurrentAssembly => Assembly.GetExecutingAssembly();
    }
}
