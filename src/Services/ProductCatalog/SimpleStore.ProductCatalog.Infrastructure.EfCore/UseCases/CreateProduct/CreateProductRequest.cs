using MediatR;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.CreateProduct
{
    public class CreateProductRequest : IRequest
    {
        public string ProductName { get; set; }
    }
}
