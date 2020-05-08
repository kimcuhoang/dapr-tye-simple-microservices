using HotChocolate.Types;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.AddOrUpdateProductInventory;

namespace SimpleStore.InventoriesApi.GraphQL.InputTypes
{
    public class AddOrUpdateProductInventoryRequestType : InputObjectType<AddOrdUpdateProductInventoryRequest>
    {
        #region Overrides of InputObjectType<AddProductToInventoryRequest>

        protected override void Configure(IInputObjectTypeDescriptor<AddOrdUpdateProductInventoryRequest> descriptor)
        {
            descriptor.Name($"{nameof(ServiceOptions.InventoriesApi)}_{nameof(AddOrdUpdateProductInventoryRequest)}");
        }

        #endregion
    }
}
