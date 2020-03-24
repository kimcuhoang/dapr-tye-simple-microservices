using System;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways.Models
{
    public class ProductInventory
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public bool CanPurchase { get; set; }
    }
}
