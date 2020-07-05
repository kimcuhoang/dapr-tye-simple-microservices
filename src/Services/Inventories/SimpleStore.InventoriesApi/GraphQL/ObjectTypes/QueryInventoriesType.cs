using HotChocolate.Types;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;
using SimpleStore.InventoriesApi.GraphQL.InputTypes;
using SimpleStore.InventoriesApi.GraphQL.Objects;

namespace SimpleStore.InventoriesApi.GraphQL.ObjectTypes
{
    public class QueryInventoriesType : ObjectType<QueryInventories>
    {
        #region Overrides of ObjectType<QueryInventories>

        protected override void Configure(IObjectTypeDescriptor<QueryInventories> descriptor)
        {
            var prefix = nameof(ServiceOptions.InventoriesApi);

            descriptor
                .Field(x => x.GetInventories(default)).Type<GetInventoriesResponseType>()
                .Argument("request", arg => arg.Type<NonNullType<GetInventoriesRequestType>>())
                .Name($"{prefix}_{nameof(QueryInventories.GetInventories)}");

            descriptor
                .Field(x => x.GetProducts(default)).Type<GetProductsResponseType>()
                .Argument("request", arg => arg.Type<NonNullType<GetProductsRequestType>>())
                .Name($"{prefix}_{nameof(QueryInventories.GetProducts)}");

            descriptor
                .Field(x => x.GetProductsByIds(default)).Type<GetProductsByIdsResponseType>()
                .Argument("request", arg => arg.Type<NonNullType<GetProductsByIdsRequestType>>())
                .Name($"{prefix}_{nameof(QueryInventories.GetProductsByIds)}");
        }

        #endregion
    }
}
