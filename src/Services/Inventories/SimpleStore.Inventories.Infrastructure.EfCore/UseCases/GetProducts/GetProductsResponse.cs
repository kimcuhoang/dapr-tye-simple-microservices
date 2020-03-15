using SimpleStore.Inventories.Infrastructure.EfCore.Dto;
using System.Collections.Generic;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetProducts
{
    public class GetProductsResponse
    {
        public int TotalOfProducts { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
