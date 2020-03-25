using System;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Dto
{
    public class InventoryDto
    {
        public Guid InventoryId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Quantity { get; set; }
        public bool CanPurchase { get; set; }
    }
}
