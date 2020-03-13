using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleStore.Inventories.Domain.Models;

namespace SimpleStore.Inventories.Infrastructure.EfCore.Mappings
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

            builder
                .HasMany(x => x.Inventories)
                .WithOne()
                .HasForeignKey(x => x.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }

        #endregion
    }
}
