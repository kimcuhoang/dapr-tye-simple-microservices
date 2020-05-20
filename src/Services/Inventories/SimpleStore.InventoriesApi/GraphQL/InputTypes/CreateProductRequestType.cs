using HotChocolate.Types;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.CreateProduct;

namespace SimpleStore.InventoriesApi.GraphQL.InputTypes
{
    public class CreateProductRequestType : InputObjectType<CreateProductRequest>
    {
        #region Overrides of InputObjectType<CreateProductRequest>

        protected override void Configure(IInputObjectTypeDescriptor<CreateProductRequest> descriptor)
        {
            descriptor.Name($"{nameof(ServiceOptions.InventoriesApi)}_{nameof(CreateProductRequest)}");
        }

        #endregion
    }
}
