namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways.Models
{
    public class GetInventoriesRequest
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 100;
    }
}
