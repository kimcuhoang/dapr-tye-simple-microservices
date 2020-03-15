using MediatR;
using System;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.CreateProduct
{
    public class CreateProductRequest : IRequest<CreateProductResponse>
    {
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; }
    }
}
