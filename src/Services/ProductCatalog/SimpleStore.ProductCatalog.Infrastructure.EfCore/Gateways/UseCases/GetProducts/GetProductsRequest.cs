namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways.UseCases.GetProducts
{
    public class GetProductsRequest
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
