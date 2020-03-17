using SimpleStore.Domain.Models;
using System;

namespace SimpleStore.Inventories.Domain.Models
{
    public class ProductInventoryId : IdentityBase
    {
        private ProductInventoryId(Guid id) : base(id) { }

        public static explicit operator ProductInventoryId(Guid id) => id == Guid.Empty ? null : new ProductInventoryId(id);
    }
}
