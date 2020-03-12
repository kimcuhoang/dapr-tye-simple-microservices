using MediatR;
using SimpleStore.Inventory.Infrastructure.EfCore.Dto;
using SimpleStore.Inventory.Infrastructure.EfCore.UseCases.CreateInventory;
using System.Threading.Tasks;

namespace SimpleStore.InventoryApi.GraphQL.Objects
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
