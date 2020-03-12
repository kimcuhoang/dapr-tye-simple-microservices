using HotChocolate.Types;
using SimpleStore.InventoryApi.GraphQL.InputTypes;
using SimpleStore.InventoryApi.GraphQL.Objects;

namespace SimpleStore.InventoryApi.GraphQL.ObjectTypes
{
    public class QueryInventoriesType : ObjectType<QueryInventories>
    {
        #region Overrides of ObjectType<QueryInventories>

        protected override void Configure(IObjectTypeDescriptor<QueryInventories> descriptor)
        {
            descriptor
                .Field(x => x.GetInventories(default)).Type<GetInventoriesResponseType>()
                .Argument("request", arg => arg.Type<NonNullType<GetInventoriesRequestType>>())
                .Name("inventories");
        }

        #endregion
    }
}
