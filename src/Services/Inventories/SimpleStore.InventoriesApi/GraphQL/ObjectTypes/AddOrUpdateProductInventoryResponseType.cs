using HotChocolate.Types;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.AddOrUpdateProductInventory;

namespace SimpleStore.InventoriesApi.GraphQL.ObjectTypes
{
    public class AddOrUpdateProductInventoryResponseType : ObjectType<AddOrUpdateProductInventoryResponse>
    {
        #region Overrides of ObjectType<AddProductToInventoryResponse>

        protected override void Configure(IObjectTypeDescriptor<AddOrUpdateProductInventoryResponse> descriptor)
        {
            descriptor.Name($"{nameof(ServiceOptions.InventoriesApi)}_{nameof(AddOrUpdateProductInventoryResponse)}");
        }

        #endregion
    }
}
