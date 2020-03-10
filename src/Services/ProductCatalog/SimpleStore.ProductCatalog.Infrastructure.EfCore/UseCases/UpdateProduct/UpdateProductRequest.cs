using MediatR;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Dto;
using System;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.UpdateProduct
{
    public class UpdateProductRequest : IRequest<ProductDto>
    {
        public Guid ProductId { get; set; }
        public string NewProductName { get; set; }
    }
}
