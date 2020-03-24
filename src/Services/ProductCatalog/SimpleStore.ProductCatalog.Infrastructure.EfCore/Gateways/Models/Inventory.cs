using System;
using System.Collections.Generic;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways.Models
{
    public class Inventory
    {
        public Guid InventoryId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public IEnumerable<ProductInventory> Products { get; set; }
    }
}
