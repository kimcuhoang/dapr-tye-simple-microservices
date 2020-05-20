using HotChocolate.Types;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.CreateInventory;

namespace SimpleStore.InventoriesApi.GraphQL.InputTypes
{
    public class CreateInventoryRequestType : InputObjectType<CreateInventoryRequest>
    {
        #region Overrides of InputObjectType<CreateInventoryRequest>

        protected override void Configure(IInputObjectTypeDescriptor<CreateInventoryRequest> descriptor)
        {
            descriptor.Name($"{nameof(ServiceOptions.InventoriesApi)}_{nameof(CreateInventoryRequest)}");
        }

        #endregion
    }
}
