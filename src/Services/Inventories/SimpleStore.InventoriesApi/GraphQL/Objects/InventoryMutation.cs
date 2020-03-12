using System.Threading.Tasks;
using MediatR;
using SimpleStore.Inventories.Infrastructure.EfCore.Dto;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.CreateInventory;

namespace SimpleStore.InventoriesApi.GraphQL.Objects
{
    public class InventoryMutation
    {
        private readonly IMediator _mediator;

        public InventoryMutation(IMediator mediator)
            => this._mediator = mediator;

        public async Task<InventoryDto> CreateInventory(CreateInventoryRequest request)
            => await this._mediator.Send(request);
    }
}
