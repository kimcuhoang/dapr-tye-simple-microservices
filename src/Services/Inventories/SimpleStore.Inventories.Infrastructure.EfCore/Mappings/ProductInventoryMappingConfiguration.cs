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
            builder
                .Property(x => x.Id)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasConversion(x => x.Id, id => (ProductInventoryId)id);

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.Inventories)
                .HasForeignKey("ProductId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder
                .HasOne(x => x.Inventory)
                .WithMany(x => x.Products)
                .HasForeignKey("InventoryId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }

        #endregion
    }
}
