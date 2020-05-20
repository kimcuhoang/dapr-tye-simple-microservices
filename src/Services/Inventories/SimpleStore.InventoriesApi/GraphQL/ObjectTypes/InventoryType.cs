using HotChocolate.Types;
using SimpleStore.Inventories.Infrastructure.EfCore.Dto;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;

namespace SimpleStore.InventoriesApi.GraphQL.ObjectTypes
{
    public class InventoryType : ObjectType<InventoryDto>
    {
        #region Overrides of ObjectType<InventoryDto>

        protected override void Configure(IObjectTypeDescriptor<InventoryDto> descriptor)
        {
            descriptor.Name($"{nameof(ServiceOptions.InventoriesApi)}_{nameof(InventoryDto)}");
        }

        #endregion
    }
}
