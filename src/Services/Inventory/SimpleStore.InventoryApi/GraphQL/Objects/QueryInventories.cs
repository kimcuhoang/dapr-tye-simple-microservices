using MediatR;
using SimpleStore.Inventory.Infrastructure.EfCore.UseCases.GetInventories;
using System.Threading.Tasks;

namespace SimpleStore.InventoryApi.GraphQL.Objects
{
    public class QueryInventories
    {
        private readonly IMediator _mediator;

        public QueryInventories(IMediator mediator)
            => this._mediator = mediator;

        public async Task<GetInventoriesResponse> GetInventories(GetInventoriesRequest request)
            => await this._mediator.Send(request);
    }
}
