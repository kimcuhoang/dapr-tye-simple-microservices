using HotChocolate.Types;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetInventories;

namespace SimpleStore.InventoriesApi.GraphQL.InputTypes
{
    public class GetInventoriesRequestType : ObjectType<GetInventoriesRequest>
    {
        #region Overrides of ObjectType<GetInventoriesRequest>

        protected override void Configure(IObjectTypeDescriptor<GetInventoriesRequest> descriptor)
        {
            descriptor.Name($"{nameof(ServiceOptions.InventoriesApi)}_{nameof(GetInventoriesRequest)}");
        }

        #endregion
    }
}
