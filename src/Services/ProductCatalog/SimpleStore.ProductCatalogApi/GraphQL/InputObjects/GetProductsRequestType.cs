using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Options;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.GetProducts;

namespace SimpleStore.ProductCatalogApi.GraphQL.InputObjects
{
    public class GetProductsRequestType : InputObjectType<GetProductsRequest>
    {
        #region Overrides of InputObjectType<GetProductsRequest>

        protected override void Configure(IInputObjectTypeDescriptor<GetProductsRequest> descriptor)
        {
            descriptor.Name($"{nameof(ServiceOptions.ProductCatalogApi)}_{nameof(GetProductsRequest)}");
        }

        #endregion
    }
}
