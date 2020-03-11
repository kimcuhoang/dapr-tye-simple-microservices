using HotChocolate.Types;
using SimpleStore.ProductCatalogApi.GraphQL.Objects;

namespace SimpleStore.ProductCatalogApi.GraphQL.ObjectTypes
{
    public class QueryType : ObjectType<Query>
    {
        #region Overrides of ObjectType<Query>

        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor
                .Field(x => x.GetProducts(default))
                .Type<GetProductsResponseType>()
                .Argument("request", arg => arg.Type<NonNullType<GetProductsRequestType>>())
                .Name("products");
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
