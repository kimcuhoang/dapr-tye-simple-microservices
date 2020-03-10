using System;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Dto
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
    }
}
