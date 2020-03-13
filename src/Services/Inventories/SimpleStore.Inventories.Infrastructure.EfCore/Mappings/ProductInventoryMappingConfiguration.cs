using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleStore.Inventories.Domain.Models;

namespace SimpleStore.Inventories.Infrastructure.EfCore.Mappings
{
    public class ProductInventoryMappingConfiguration : IEntityTypeConfiguration<ProductInventory>
    {
        #region Implementation of IEntityTypeConfiguration<ProductInventory>

        public void Configure(EntityTypeBuilder<ProductInventory> builder)
        {
            builder.HasKey(x => x.ProductInventoryId);
            builder
                .Property(x => x.ProductInventoryId)
                .HasField("Id")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasConversion(x => x.Id, id => (ProductInventoryId)id);

            builder
                .Property(x => x.ProductId)
                .IsRequired()
                .HasConversion(x => x.Id, id => (ProductId)id);

            builder
                .Property(x => x.InventoryId)
                .IsRequired()
                .HasConversion(x => x.Id, id => (InventoryId)id);
        }

        #endregion
    }
}
