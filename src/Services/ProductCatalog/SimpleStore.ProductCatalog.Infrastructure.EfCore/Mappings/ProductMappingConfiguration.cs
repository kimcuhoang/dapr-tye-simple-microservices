using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleStore.ProductCatalog.Domain.Models;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Mappings
{
    public class ProductMappingConfiguration : IEntityTypeConfiguration<Product>
    {
        #region Implementation of IEntityTypeConfiguration<Product>

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId);

            builder
                .Property(x => x.ProductId)
                .HasField("Id")
                .HasColumnName("Id")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasConversion(x => x.Id, id => (ProductId)id);

            builder.HasData(
                    Product.Create("PRD-1", "Product-1"), 
                    Product.Create("PRD-2", "Product-2"), 
                    Product.Create("PRD-3","Product-3"));
        }

        #endregion
    }
}
