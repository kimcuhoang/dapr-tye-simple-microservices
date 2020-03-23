using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;
using SimpleStore.InventoriesApi.GraphQL.InputTypes;
using SimpleStore.InventoriesApi.GraphQL.Objects;

namespace SimpleStore.InventoriesApi.GraphQL.ObjectTypes
{
    public class QueryInventoriesType : ObjectType<QueryInventories>
    {
        private readonly ServiceOptions _serviceOptions;

        public QueryInventoriesType(IOptions<ServiceOptions> serviceOptions)
            => this._serviceOptions = serviceOptions.Value;

        #region Overrides of ObjectType<QueryInventories>

        protected override void Configure(IObjectTypeDescriptor<QueryInventories> descriptor)
        {
            descriptor
                .Field(x => x.GetInventories(default)).Type<GetInventoriesResponseType>()
                .Argument("request", arg => arg.Type<NonNullType<GetInventoriesRequestType>>())
                .Name($"{this._serviceOptions.InventoriesApi.ServiceName}_{nameof(QueryInventories.GetInventories)}");

            descriptor
                .Field(x => x.GetProducts(default)).Type<GetProductsResponseType>()
                .Argument("request", arg => arg.Type<NonNullType<GetProductsRequestType>>())
                .Name($"{this._serviceOptions.InventoriesApi.ServiceName}_{nameof(QueryInventories.GetProducts)}");
        }

        #endregion
    }
}
