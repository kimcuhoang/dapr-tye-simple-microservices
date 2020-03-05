using System;
using System.ComponentModel;
using SimpleStore.Domain.Models;

namespace SimpleStore.ProductCatalog.Domain.Models
{
    [TypeConverter(typeof(IdentityBaseTypeConverter<ProductId>))]
    public class ProductId : IdentityBase
    {
        private ProductId(Guid id) : base(id) { }

        public static explicit operator ProductId(Guid id) => id == Guid.Empty ? null : new ProductId(id);
    }
}
