using HotChocolate.Types;
using SimpleStore.Inventory.Infrastructure.EfCore.UseCases.GetInventories;

namespace SimpleStore.InventoryApi.GraphQL.InputTypes
{
    public class GetInventoriesRequestType : ObjectType<GetInventoriesRequest>
    {
        #region Overrides of ObjectType<GetInventoriesRequest>

        protected override void Configure(IObjectTypeDescriptor<GetInventoriesRequest> descriptor)
        {
            
        }

        #endregion
    }
}
