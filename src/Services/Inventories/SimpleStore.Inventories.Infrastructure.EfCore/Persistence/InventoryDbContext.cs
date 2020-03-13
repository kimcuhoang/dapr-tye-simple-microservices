using Microsoft.EntityFrameworkCore;
using SimpleStore.Infrastructure.EfCore.Persistence;
using SimpleStore.Inventories.Domain.Models;
using System.Collections.Generic;
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

            var inventories = new List<Inventory>
            {
                Inventory.Create($"{nameof(Inventory)}-1", $"{nameof(Inventory)}-1-Location"),
                Inventory.Create($"{nameof(Inventory)}-2", $"{nameof(Inventory)}-2-Location"),
                Inventory.Create($"{nameof(Inventory)}-3", $"{nameof(Inventory)}-3-Location")
            };

            var products = new List<Product>
            {
                Product.Of("PRD-1"),
                Product.Of("PRD-2"),
                Product.Of("PRD-3"),
            };

            //inventories[0].AddProduct(products[0].ProductId, 10);
            //inventories[0].AddProduct(products[2].ProductId, 5);

            //inventories[1].AddProduct(products[0].ProductId, 3);
            //inventories[1].AddProduct(products[1].ProductId, 1);

            //inventories[2].AddProduct(products[1].ProductId, 9);
            //inventories[2].AddProduct(products[2].ProductId, 8);

            builder.Entity<Product>().HasData(products);

            builder.Entity<Inventory>().HasData(inventories);
        }

        #endregion
    }
}
