using HotChocolate.Types;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Options;
using SimpleStore.ProductCatalogApi.GraphQL.InputObjects;
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
                .Name($"{nameof(ServiceOptions.ProductCatalogApi)}_{nameof(Query.GetProducts)}");
        }

        #endregion
    }
}