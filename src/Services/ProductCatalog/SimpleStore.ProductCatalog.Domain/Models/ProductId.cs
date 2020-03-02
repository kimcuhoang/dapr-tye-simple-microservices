using System;
using SimpleStore.Domain.Models;

namespace SimpleStore.ProductCatalog.Domain.Models
{
    public class ProductId : IdentityBase
    {
        private ProductId(Guid id) : base(id) { }

        public static explicit operator ProductId(Guid id) => id == Guid.Empty ? null : new ProductId(id);
    }
}
