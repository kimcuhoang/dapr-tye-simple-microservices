using System;
using System.Collections.Generic;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetProductsByIds
{
    public class GetProductsByIdsResponse
    {
        public IEnumerable<ProductResult> Products { get; set; }

        public class ProductResult
        {
            public Guid Id { get; set; }
            public string Code { get; set; }

            public IEnumerable<ProductInventoryResult> Inventories { get; set; }
        }

        public class ProductInventoryResult
        {
            public Guid InventoryId { get; set; }
            public string Name { get; set; }
            public string Location { get; set; }
            public int Quantity { get; set; }
            public bool CanPurchase { get; set; }
        }
    }
}
