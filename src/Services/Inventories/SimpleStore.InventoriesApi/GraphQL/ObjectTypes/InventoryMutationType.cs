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
                .Name("CreateInventory");
        }

        #endregion
    }
}
