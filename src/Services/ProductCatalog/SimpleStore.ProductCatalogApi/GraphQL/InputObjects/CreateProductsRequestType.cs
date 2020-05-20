using HotChocolate.Types;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Options;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.CreateProduct;

namespace SimpleStore.ProductCatalogApi.GraphQL.InputObjects
{
    public class CreateProductsRequestType : InputObjectType<CreateProductRequest>
    {
        #region Overrides of InputObjectType<CreateProductRequest>

        protected override void Configure(IInputObjectTypeDescriptor<CreateProductRequest> descriptor)
        {
            descriptor.Name($"{nameof(ServiceOptions.ProductCatalogApi)}_{nameof(CreateProductRequest)}");
        }

        #endregion
    }
}
