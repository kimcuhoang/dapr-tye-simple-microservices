using MediatR;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Dto;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.CreateProduct;
using System.Threading.Tasks;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.UpdateProduct;

namespace SimpleStore.ProductCatalogApi.GraphQL.Objects
{
    public class Mutation
    {
        private readonly IMediator _mediator;

        public Mutation(IMediator mediator)
            => this._mediator = mediator;

        public async Task<ProductDto> CreateProduct(CreateProductRequest request)
            => await this._mediator.Send(request);

        public async Task<ProductDto> UpdateProduct(UpdateProductRequest request)
            => await this._mediator.Send(request);
    }
}
