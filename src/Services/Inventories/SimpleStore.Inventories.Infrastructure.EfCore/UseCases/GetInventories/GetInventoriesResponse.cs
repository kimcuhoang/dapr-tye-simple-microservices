using System.Collections.Generic;
using SimpleStore.Inventories.Infrastructure.EfCore.Dto;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetInventories
{
    public class GetInventoriesResponse
    {
        public IEnumerable<InventoryDto> Inventories { get; set; }
        public int TotalRecords { get; set; }
    }
}
