using HotChocolate.Types;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Dto;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Options;

namespace SimpleStore.ProductCatalogApi.GraphQL.ObjectTypes
{
    public class ProductType : ObjectType<ProductDto>
    {
        #region Overrides of ObjectType<Product>

        protected override void Configure(IObjectTypeDescriptor<ProductDto> descriptor)
        {
            descriptor.Name($"{nameof(ServiceOptions.ProductCatalogApi)}_{nameof(ProductDto)}");
        }

        #endregion
    }
}
