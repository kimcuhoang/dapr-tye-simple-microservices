using HotChocolate.Types;
using SimpleStore.InventoryApi.GraphQL.InputTypes;
using SimpleStore.InventoryApi.GraphQL.Objects;

namespace SimpleStore.InventoryApi.GraphQL.ObjectTypes
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
