using HotChocolate.Types;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.UpdateProduct;

namespace SimpleStore.ProductCatalogApi.GraphQL.InputObjects
{
    public class UpdateProductRequestType : InputObjectType<UpdateProductRequest>
    {
        #region Overrides of InputObjectType<UpdateProductRequest>

        protected override void Configure(IInputObjectTypeDescriptor<UpdateProductRequest> descriptor)
        {
            descriptor.Name(nameof(UpdateProductRequest));
        }

        #endregion
    }
}
