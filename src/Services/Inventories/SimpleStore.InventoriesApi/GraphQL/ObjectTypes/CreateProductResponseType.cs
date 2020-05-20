using HotChocolate.Types;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.CreateProduct;

namespace SimpleStore.InventoriesApi.GraphQL.ObjectTypes
{
    public class CreateProductResponseType : ObjectType<CreateProductResponse>
    {
        #region Overrides of ObjectType<CreateProductResponse>

        protected override void Configure(IObjectTypeDescriptor<CreateProductResponse> descriptor)
        {
            descriptor.Name($"{nameof(ServiceOptions.InventoriesApi)}_{nameof(CreateProductResponse)}");
        }

        #endregion
    }
}
