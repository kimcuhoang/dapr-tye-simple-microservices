using SimpleStore.ProductCatalog.Infrastructure.EfCore.Dto;
using System.Collections.Generic;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.GetProducts
{
    public class GetProductsResponse
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public int TotalOfProducts { get; set; }
    }
}
