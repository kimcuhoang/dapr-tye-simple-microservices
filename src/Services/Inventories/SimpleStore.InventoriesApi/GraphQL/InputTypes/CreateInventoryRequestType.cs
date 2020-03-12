using HotChocolate.Types;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.CreateInventory;

namespace SimpleStore.InventoriesApi.GraphQL.InputTypes
{
    public class CreateInventoryRequestType : InputObjectType<CreateInventoryRequest>
    {
        #region Overrides of InputObjectType<CreateInventoryRequest>

        protected override void Configure(IInputObjectTypeDescriptor<CreateInventoryRequest> descriptor)
        {
            
        }

        #endregion
    }
}
