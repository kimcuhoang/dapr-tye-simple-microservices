using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Dto
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public IEnumerable<InventoryDto> Inventories { get; set; }

        public int TotalAvailability => this.Inventories?.Where(x => x.CanPurchase).Sum(x => x.Quantity) ?? 0;
    }
}
