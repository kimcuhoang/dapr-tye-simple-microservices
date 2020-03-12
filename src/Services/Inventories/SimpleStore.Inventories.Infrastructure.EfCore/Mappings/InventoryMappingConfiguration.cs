using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleStore.Inventories.Domain.Models;

namespace SimpleStore.Inventories.Infrastructure.EfCore.Mappings
{
    public class InventoryMappingConfiguration : IEntityTypeConfiguration<Domain.Models.Inventory>
    {
        #region Implementation of IEntityTypeConfiguration<Inventory>

        public void Configure(EntityTypeBuilder<Domain.Models.Inventory> builder)
        {
            builder.HasKey(x => x.InventoryId);

            builder
                .Property(x => x.InventoryId)
                .HasField("Id")
                .HasColumnName("Id")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasConversion(x => x.Id, id => (InventoryId)id);

            builder.HasData(
                Domain.Models.Inventory.Create($"{nameof(Domain.Models.Inventory)}-1",
                    $"{nameof(Domain.Models.Inventory)}-1-Location"),
                Domain.Models.Inventory.Create($"{nameof(Domain.Models.Inventory)}-2",
                    $"{nameof(Domain.Models.Inventory)}-2-Location"),
                Domain.Models.Inventory.Create($"{nameof(Domain.Models.Inventory)}-3",
                    $"{nameof(Domain.Models.Inventory)}-3-Location"));
        }

        #endregion
    }
}
