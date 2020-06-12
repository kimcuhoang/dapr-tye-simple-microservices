using System.Collections.Generic;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways.UseCases.GetInventories
{
    public class GetInventoriesResponse
    {
        public IEnumerable<Inventory> Inventories { get; set; }
        public int TotalRecords { get; set; }
    }
}
