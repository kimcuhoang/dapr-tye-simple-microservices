using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;
using SimpleStore.InventoriesApi.GraphQL.InputTypes;
using SimpleStore.InventoriesApi.GraphQL.Objects;

namespace SimpleStore.InventoriesApi.GraphQL.ObjectTypes
{
    public class InventoryMutationType : ObjectType<InventoryMutation>
    {
        private readonly ServiceOptions _serviceOptions;

        public InventoryMutationType(IOptions<ServiceOptions> serviceOptions)
            => this._serviceOptions = serviceOptions.Value;

        #region Overrides of ObjectType<InventoryMutation>

        protected override void Configure(IObjectTypeDescriptor<InventoryMutation> descriptor)
        {
            descriptor
                .Field(x => x.CreateInventory(default)).Type<InventoryType>()
                .Argument("request", arg => arg.Type<NonNullType<CreateInventoryRequestType>>())
                .Name($"{this._serviceOptions.InventoriesApi.ServiceName}_{nameof(InventoryMutation.CreateInventory)}");

            descriptor
                .Field(x => x.CreateProduct(default)).Type<CreateProductResponseType>()
                .Argument("request", arg => arg.Type<NonNullType<CreateProductRequestType>>())
                .Name($"{this._serviceOptions.InventoriesApi.ServiceName}_{nameof(InventoryMutation.CreateProduct)}");

            descriptor
                .Field(x => x.AddOrUpdateProductInventory(default)).Type<AddOrUpdateProductInventoryResponseType>()
                .Argument("request", arg => arg.Type<NonNullType<AddOrUpdateProductInventoryRequestType>>())
                .Name($"{this._serviceOptions.InventoriesApi.ServiceName}_{nameof(InventoryMutation.AddOrUpdateProductInventory)}");
        }

        #endregion
    }
}
