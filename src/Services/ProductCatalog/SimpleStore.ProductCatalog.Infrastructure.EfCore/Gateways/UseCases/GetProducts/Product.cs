using System;
using System.Collections.Generic;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways.UseCases.GetProducts
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Code { get; set; }
        public IEnumerable<Inventory> Inventories { get; set; }
    }
}
