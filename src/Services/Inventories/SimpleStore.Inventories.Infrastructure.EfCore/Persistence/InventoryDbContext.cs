using Microsoft.EntityFrameworkCore;
using SimpleStore.Infrastructure.EfCore.Persistence;
using SimpleStore.Inventories.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SimpleStore.Inventories.Infrastructure.EfCore.Persistence
{
    public class InventoryDbContext : ApplicationDbContextBase
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> dbContextOptions) : base(dbContextOptions) { }

        protected override Assembly CurrentAssembly => Assembly.GetExecutingAssembly();

        #region Overrides of ApplicationDbContextBase

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var products = new List<Product>
            {
                Product.Of("PRD-1"),
                Product.Of("PRD-2"),
                Product.Of("PRD-3"),
            };

            var inventories = new List<Inventory>
            {
                Inventory.Create($"{nameof(Inventory)}-1", $"{nameof(Inventory)}-1-Location"),
                Inventory.Create($"{nameof(Inventory)}-2", $"{nameof(Inventory)}-2-Location"),
                Inventory.Create($"{nameof(Inventory)}-3", $"{nameof(Inventory)}-3-Location")
            };

            var productInventories = new[]
            {
                ProductInventory.Create(products[0], inventories[0], 10),
                ProductInventory.Create(products[2], inventories[0], 5),
                ProductInventory.Create(products[0], inventories[1], 3),
                ProductInventory.Create(products[1], inventories[1], 1),
                ProductInventory.Create(products[1], inventories[2], 9),
                ProductInventory.Create(products[2], inventories[2], 8)
            }
            //https://stackoverflow.com/questions/60040917/ef-core-seeding-mechanism-isnt-working-with-relationships
            .Select(x => new
            {
                ProductInventoryId = x.ProductInventoryId,
                ProductId = x.Product.ProductId,
                InventoryId = x.Inventory.InventoryId,
                Quantity = x.Quantity,
                CanPurchase = x.CanPurchase
            });

            builder.Entity<Product>().HasData(products);
            builder.Entity<Inventory>().HasData(inventories);
            builder.Entity<ProductInventory>().HasData(productInventories);
        }

        #endregion
    }
}
