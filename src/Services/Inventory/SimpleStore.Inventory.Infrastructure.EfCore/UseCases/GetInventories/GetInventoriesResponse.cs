using SimpleStore.Inventory.Infrastructure.EfCore.Dto;
using System.Collections.Generic;

namespace SimpleStore.Inventory.Infrastructure.EfCore.UseCases.GetInventories
{
    public class GetInventoriesResponse
    {
        public IEnumerable<InventoryDto> Inventories { get; set; }
        public int TotalRecords { get; set; }
    }
}
