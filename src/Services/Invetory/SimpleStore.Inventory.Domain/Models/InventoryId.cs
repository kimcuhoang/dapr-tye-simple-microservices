using SimpleStore.Domain.Models;
using System;

namespace SimpleStore.Inventory.Domain.Models
{
    public class InventoryId : IdentityBase
    {
        private InventoryId(Guid id) : base(id) { }

        public static explicit operator InventoryId(Guid id) => id == Guid.Empty ? null : new InventoryId(id);
    }
}
