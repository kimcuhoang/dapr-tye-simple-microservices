using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleStore.Inventories.Domain.Models;

namespace SimpleStore.Inventories.Infrastructure.EfCore.Mappings
{
    public class InventoryMappingConfiguration : IEntityTypeConfiguration<Domain.Models.Inventory>
    {
        #region Implementation of IEntityTypeConfiguration<Inventory>

        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(x => x.InventoryId);

            builder
                .Property(x => x.InventoryId)
                .HasField("Id")
                .HasColumnName("Id")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasConversion(x => x.Id, id => (InventoryId)id);

            builder.Metadata
                .FindNavigation(nameof(Inventory.Products))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            //builder
            //    .HasMany(x => x.Products)
            //    .WithOne(x => x.Inventory)
            //    .HasForeignKey(x => x.InventoryId)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);
        }

        #endregion
    }
}
