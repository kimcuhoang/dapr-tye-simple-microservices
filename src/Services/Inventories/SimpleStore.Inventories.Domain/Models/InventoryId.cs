using System;
using SimpleStore.Domain.Models;

namespace SimpleStore.Inventories.Domain.Models
{
    public class InventoryId : IdentityBase
    {
        private InventoryId(Guid id) : base(id) { }

        public static explicit operator InventoryId(Guid id) => id == Guid.Empty ? null : new InventoryId(id);
    }
}
