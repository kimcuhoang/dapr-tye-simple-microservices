using System.Threading.Tasks;
using MediatR;
using SimpleStore.Inventories.Infrastructure.EfCore.Dto;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.AddOrUpdateProductInventory;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.CreateInventory;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.CreateProduct;

namespace SimpleStore.InventoriesApi.GraphQL.Objects
{
    public class InventoryMutation
    {
        private readonly IMediator _mediator;

        public InventoryMutation(IMediator mediator)
            => this._mediator = mediator;

        public async Task<InventoryDto> CreateInventory(CreateInventoryRequest request)
            => await this._mediator.Send(request);

        public async Task<CreateProductResponse> CreateProduct(CreateProductRequest request)
            => await this._mediator.Send(request);

        public async Task<AddOrUpdateProductInventoryResponse> AddOrUpdateProductInventory(AddOrdUpdateProductInventoryRequest request)
            => await this._mediator.Send(request);
    }
}
