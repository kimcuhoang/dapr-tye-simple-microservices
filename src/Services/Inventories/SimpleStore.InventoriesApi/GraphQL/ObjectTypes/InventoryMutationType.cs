using HotChocolate.Types;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;
using SimpleStore.InventoriesApi.GraphQL.InputTypes;
using SimpleStore.InventoriesApi.GraphQL.Objects;

namespace SimpleStore.InventoriesApi.GraphQL.ObjectTypes
{
    public class InventoryMutationType : ObjectType<InventoryMutation>
    {
        #region Overrides of ObjectType<InventoryMutation>

        protected override void Configure(IObjectTypeDescriptor<InventoryMutation> descriptor)
        {
            var prefix = nameof(ServiceOptions.InventoriesApi);

            descriptor
                .Field(x => x.CreateInventory(default)).Type<InventoryType>()
                .Argument("request", arg => arg.Type<NonNullType<CreateInventoryRequestType>>())
                .Name($"{prefix}_{nameof(InventoryMutation.CreateInventory)}");

            descriptor
                .Field(x => x.CreateProduct(default)).Type<CreateProductResponseType>()
                .Argument("request", arg => arg.Type<NonNullType<CreateProductRequestType>>())
                .Name($"{prefix}_{nameof(InventoryMutation.CreateProduct)}");

            descriptor
                .Field(x => x.AddOrUpdateProductInventory(default)).Type<AddOrUpdateProductInventoryResponseType>()
                .Argument("request", arg => arg.Type<NonNullType<AddOrUpdateProductInventoryRequestType>>())
                .Name($"{prefix}_{nameof(InventoryMutation.AddOrUpdateProductInventory)}");
        }

        #endregion
    }
}
