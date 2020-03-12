using System;
using System.Collections.Generic;
using System.Text;
using SimpleStore.Domain.Models;

namespace SimpleStore.Inventories.Domain.Models
{
    public class ProductInventory : EntityBase
    {
        public ProductInventoryId ProductInventoryId => (ProductInventoryId) this.Id;

        public ProductId ProductId { get; private set; }
        public InventoryId InventoryId { get; private set; }
        public int Quantity { get; private set; }
        public bool CanPurchase { get; private set; }
    }
}
