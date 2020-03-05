using MediatR;
using SimpleStore.ProductCatalog.Domain.Models;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.UpdateProduct
{
    public class UpdateProductRequest : IRequest
    {
        public ProductId ProductId { get; set; }
        public string NewProductName { get; set; }
    }
}
