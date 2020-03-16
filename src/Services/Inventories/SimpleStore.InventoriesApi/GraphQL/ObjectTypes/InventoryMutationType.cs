using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.InventoriesApi.GraphQL.InputTypes;
using SimpleStore.InventoriesApi.GraphQL.Objects;
using SimpleStore.InventoriesApi.Options;

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
                .Field(x => x.AddProductToInventory(default)).Type<AddProductToInventoryResponseType>()
                .Argument("request", arg => arg.Type<NonNullType<AddProductToInventoryRequestType>>())
                .Name($"{this._serviceOptions.InventoriesApi.ServiceName}_{nameof(InventoryMutation.AddProductToInventory)}");
        }

        #endregion
    }
}
