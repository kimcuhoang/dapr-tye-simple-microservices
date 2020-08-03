using System;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Infrastructure.EfCore.Persistence;
using SimpleStore.Inventories.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SimpleStore.Domain.Models;

namespace SimpleStore.Inventories.Infrastructure.EfCore.Persistence
{
    public class InventoryDbContext : ApplicationDbContextBase
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> dbContextOptions, IDomainEventDispatcher domainEventDispatcher) 
            : base(dbContextOptions, domainEventDispatcher) { }

        protected override Assembly CurrentAssembly => Assembly.GetExecutingAssembly();

        #region Overrides of ApplicationDbContextBase

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var products = new List<Product>
            {
                Product.Of((ProductId)new Guid("4a2abe51-e895-49be-878a-0729535ba92e"), "PRD-1"),
                Product.Of((ProductId)new Guid("1d250f1d-1546-47f3-92d2-31fbf87a3511"), "PRD-2"),
                Product.Of((ProductId)new Guid("4012d62c-2bea-42eb-9e64-d7b22185c4f0"), "PRD-3"),
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
                Id = x.Id,
                ProductId = x.Product.Id,
                InventoryId = x.Inventory.Id,
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
