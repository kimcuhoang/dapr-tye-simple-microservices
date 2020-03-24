using System;
using System.Collections.Generic;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways.Models;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Dto
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public IEnumerable<Inventory> Inventories { get; set; }
    }
}
