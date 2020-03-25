using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Options;
using SimpleStore.ProductCatalogApi.GraphQL.InputObjects;
using SimpleStore.ProductCatalogApi.GraphQL.Objects;

namespace SimpleStore.ProductCatalogApi.GraphQL.ObjectTypes
{
    public class QueryType : ObjectType<Query>
    {
        private readonly ServiceOptions _serviceOptions;

        public QueryType(IOptions<ServiceOptions> serviceOptions)
            => this._serviceOptions = serviceOptions.Value;

        #region Overrides of ObjectType<Query>

        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor
                .Field(x => x.GetProducts(default))
                .Type<GetProductsResponseType>()
                .Argument("request", arg => arg.Type<NonNullType<GetProductsRequestType>>())
                .Name($"{this._serviceOptions.ProductCatalogApi.ServiceName}_{nameof(Query.GetProducts)}");
        }

        #endregion
    }
}


/*
query products($getProductsRequest: GetProductsRequest!){
  products(request: $getProductsRequest) {
    products {
      productId,
      name
    },
    totalOfProducts
  }
}
//variables
{
  "getProductsRequest": {
    "pageIndex": 1,
    "pageSize": 10
  }
}

*/
