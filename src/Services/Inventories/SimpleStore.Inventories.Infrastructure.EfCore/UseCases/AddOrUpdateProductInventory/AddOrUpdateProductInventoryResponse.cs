using System;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.AddOrUpdateProductInventory
{
    public class AddOrUpdateProductInventoryResponse
    {
        public Guid ProductId { get; set; }
        public Guid InventoryId { get; set; }
        public string Code { get; set; }
        public string InventoryName { get; set; }
        public int Quantity { get; set; }
        public bool CanPurchase { get; set; }
    }
}
