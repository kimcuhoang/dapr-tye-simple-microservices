using System;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways.UseCases.GetProducts
{
    public class Inventory
    {
        public Guid InventoryId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Quantity { get; set; }
        public bool CanPurchase { get; set; }
    }
}
