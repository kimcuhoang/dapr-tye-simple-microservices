using System;
using System.Collections.Generic;

namespace SimpleStore.Inventories.Infrastructure.EfCore.Dto
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string Code { get; set; }
        public IEnumerable<InventoryProductDto> Inventories { get; set; }
    }
}
