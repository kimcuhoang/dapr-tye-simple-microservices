using System;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.CreateProduct
{
    public class CreateProductResponse
    {
        public Guid ProductId { get; set; }
        public string Code { get; set; }
    }
}
