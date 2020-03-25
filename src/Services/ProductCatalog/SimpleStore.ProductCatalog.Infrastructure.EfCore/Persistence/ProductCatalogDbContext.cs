using Microsoft.EntityFrameworkCore;
using SimpleStore.Domain.Models;
using SimpleStore.Infrastructure.EfCore.Persistence;
using System.Reflection;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Persistence
{
    public class ProductCatalogDbContext : ApplicationDbContextBase
    {
        public ProductCatalogDbContext(DbContextOptions<ProductCatalogDbContext> dbContextOptions, IDomainEventDispatcher domainEventDispatcher) 
            : base(dbContextOptions, domainEventDispatcher) { }

        protected override Assembly CurrentAssembly => Assembly.GetExecutingAssembly();
    }
}
