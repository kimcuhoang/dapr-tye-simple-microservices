using System.Threading.Tasks;
using MediatR;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.GetProducts;

namespace SimpleStore.ProductCatalogApi.GraphQL.Objects
{
    public class Query
    {
        private readonly IMediator _mediator;

        public Query(IMediator mediator)
            => this._mediator = mediator;

        public async Task<GetProductsResponse> GetProducts(GetProductsRequest request)
            => await this._mediator.Send(request);
    }
}
