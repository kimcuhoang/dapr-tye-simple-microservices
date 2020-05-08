using HotChocolate.Types;
using SimpleStore.Inventories.Infrastructure.EfCore.Dto;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;

namespace SimpleStore.InventoriesApi.GraphQL.ObjectTypes
{
    public class ProductType : ObjectType<ProductDto>
    {
        #region Overrides of ObjectType<ProductDto>

        protected override void Configure(IObjectTypeDescriptor<ProductDto> descriptor)
        {
            descriptor.Name($"{nameof(ServiceOptions.InventoriesApi)}_{nameof(ProductDto)}");
        }

        #endregion
    }
}
