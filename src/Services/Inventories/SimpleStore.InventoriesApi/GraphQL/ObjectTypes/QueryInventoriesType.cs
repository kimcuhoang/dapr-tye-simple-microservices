using HotChocolate.Types;
using SimpleStore.InventoriesApi.GraphQL.InputTypes;
using SimpleStore.InventoriesApi.GraphQL.Objects;

namespace SimpleStore.InventoriesApi.GraphQL.ObjectTypes
{
    public class QueryInventoriesType : ObjectType<QueryInventories>
    {
        #region Overrides of ObjectType<QueryInventories>

        protected override void Configure(IObjectTypeDescriptor<QueryInventories> descriptor)
        {
            descriptor
                .Field(x => x.GetInventories(default)).Type<GetInventoriesResponseType>()
                .Argument("request", arg => arg.Type<NonNullType<GetInventoriesRequestType>>())
                .Name(nameof(QueryInventories.GetInventories));

            descriptor
                .Field(x => x.GetProducts(default)).Type<GetProductsResponseType>()
                .Argument("request", arg => arg.Type<NonNullType<GetProductsRequestType>>())
                .Name(nameof(QueryInventories.GetProducts));
        }

        #endregion
    }
}
