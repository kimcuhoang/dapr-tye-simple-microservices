using Microsoft.EntityFrameworkCore;
using SimpleStore.Infrastructure.EfCore;
using SimpleStore.ProductCatalog.Domain.Models;
using System.Reflection;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Persistence
{
    public class ProductCatalogDbContext : ApplicationDbContextBase
    {
        public ProductCatalogDbContext(DbContextOptions<ProductCatalogDbContext> dbContextOptions) : base(dbContextOptions) { }

        protected override Assembly CurrentAssembly => Assembly.GetExecutingAssembly();

        #region Overrides of ApplicationDbContextBase

        protected override void SeedingData(ModelBuilder builder)
        {
            builder
                .Entity<Product>()
                .HasData(new Product[]
                {
                    Product.Create("Product-1"),
                    Product.Create("Product-2"),
                    Product.Create("Product-3")
                });
        }

        #endregion
    }
}
