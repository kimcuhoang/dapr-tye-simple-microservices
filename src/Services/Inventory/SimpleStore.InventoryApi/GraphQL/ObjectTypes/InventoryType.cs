using HotChocolate.Types;
using SimpleStore.Inventory.Infrastructure.EfCore.Dto;

namespace SimpleStore.InventoryApi.GraphQL.ObjectTypes
{
    public class InventoryType : ObjectType<InventoryDto>
    {
        #region Overrides of ObjectType<InventoryDto>

        protected override void Configure(IObjectTypeDescriptor<InventoryDto> descriptor)
        {
            
        }

        #endregion
    }
}
