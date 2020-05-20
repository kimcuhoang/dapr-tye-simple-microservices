using HotChocolate.Types;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Options;
using SimpleStore.ProductCatalogApi.GraphQL.InputObjects;
using SimpleStore.ProductCatalogApi.GraphQL.Objects;

namespace SimpleStore.ProductCatalogApi.GraphQL.ObjectTypes
{
    public class MutationType : ObjectType<Mutation>
    {
        #region Overrides of ObjectType<Mutation>

        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor
                .Field(x => x.CreateProduct(default))
                .Type<ProductType>()
                .Argument("request", a => a.Type<NonNullType<CreateProductsRequestType>>())
                .Name($"{nameof(ServiceOptions.ProductCatalogApi)}_{nameof(Mutation.CreateProduct)}");

            descriptor
                .Field(x => x.UpdateProduct(default))
                .Type<ProductType>()
                .Argument("request", a => a.Type<NonNullType<UpdateProductRequestType>>())
                .Name($"{nameof(ServiceOptions.ProductCatalogApi)}_{nameof(Mutation.UpdateProduct)}");
        }

        #endregion
    }
}
