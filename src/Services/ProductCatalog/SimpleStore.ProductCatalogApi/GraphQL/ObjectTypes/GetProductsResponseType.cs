using HotChocolate.Types;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.GetProducts;

namespace SimpleStore.ProductCatalogApi.GraphQL.ObjectTypes
{
    public class GetProductsResponseType : ObjectType<GetProductsResponse>
    {
        #region Overrides of ObjectType<GetProductsResponse>

        protected override void Configure(IObjectTypeDescriptor<GetProductsResponse> descriptor)
        {
            descriptor.Name(nameof(GetProductsResponse));
        }

        #endregion
    }
}
