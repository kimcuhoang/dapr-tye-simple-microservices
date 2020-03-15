using HotChocolate.Types;
using SimpleStore.InventoriesApi.GraphQL.InputTypes;
using SimpleStore.InventoriesApi.GraphQL.Objects;

namespace SimpleStore.InventoriesApi.GraphQL.ObjectTypes
{
    public class InventoryMutationType : ObjectType<InventoryMutation>
    {
        #region Overrides of ObjectType<InventoryMutation>

        protected override void Configure(IObjectTypeDescriptor<InventoryMutation> descriptor)
        {
            descriptor
                .Field(x => x.CreateInventory(default)).Type<InventoryType>()
                .Argument("request", arg => arg.Type<NonNullType<CreateInventoryRequestType>>())
                .Name(nameof(InventoryMutation.CreateInventory));

            descriptor
                .Field(x => x.CreateProduct(default)).Type<CreateProductResponseType>()
                .Argument("request", arg => arg.Type<NonNullType<CreateProductRequestType>>())
                .Name(nameof(InventoryMutation.CreateProduct));
        }

        #endregion
    }
}
