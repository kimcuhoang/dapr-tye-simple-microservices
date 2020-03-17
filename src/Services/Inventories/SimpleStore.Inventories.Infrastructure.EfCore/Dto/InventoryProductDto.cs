using System;

namespace SimpleStore.Inventories.Infrastructure.EfCore.Dto
{
    public class InventoryProductDto
    {
        public Guid InventoryId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Quantity { get; set; }
        public bool CanPurchase { get; set; }
    }
}
