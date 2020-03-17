using System;
using System.Collections.Generic;

namespace SimpleStore.Inventories.Infrastructure.EfCore.Dto
{
    public class InventoryDto
    {
        public Guid InventoryId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public IEnumerable<ProductInventoryDto> Products { get; set; }
    }
}
