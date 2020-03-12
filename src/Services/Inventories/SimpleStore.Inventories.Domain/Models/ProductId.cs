using SimpleStore.Domain.Models;
using System;

namespace SimpleStore.Inventories.Domain.Models
{
    public class ProductId : IdentityBase
    {
        private ProductId(Guid id) : base(id) { }

        public static explicit operator ProductId(Guid id) => id == Guid.Empty ? null : new ProductId(id);
    }
}
