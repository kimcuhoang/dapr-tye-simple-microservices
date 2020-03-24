using MediatR;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Dto;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.CreateProduct
{
    public class CreateProductRequest : IRequest<ProductDto>
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
    }
}
