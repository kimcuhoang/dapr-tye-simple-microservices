using System;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways.UseCases.GetInventories
{
    public class ProductInventory
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public bool CanPurchase { get; set; }
    }
}
