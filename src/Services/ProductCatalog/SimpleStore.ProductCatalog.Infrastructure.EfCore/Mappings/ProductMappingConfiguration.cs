using System;
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
                    Product.Create((ProductId)new Guid("4a2abe51-e895-49be-878a-0729535ba92e"), "PRD-1", "Product-1"), 
                    Product.Create((ProductId)new Guid("1d250f1d-1546-47f3-92d2-31fbf87a3511"), "PRD-2", "Product-2"), 
                    Product.Create((ProductId)new Guid("4012d62c-2bea-42eb-9e64-d7b22185c4f0"), "PRD-3", "Product-3"));
        }

        #endregion
    }
}
