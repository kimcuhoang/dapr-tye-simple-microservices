using System.Collections.Generic;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways.UseCases.GetProducts
{
    public class GetProductsResponse
    {
        public int TotalOfProducts { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
