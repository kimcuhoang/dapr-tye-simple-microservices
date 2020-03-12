using HotChocolate.Types;
using SimpleStore.Inventories.Infrastructure.EfCore.Dto;

namespace SimpleStore.InventoriesApi.GraphQL.ObjectTypes
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
