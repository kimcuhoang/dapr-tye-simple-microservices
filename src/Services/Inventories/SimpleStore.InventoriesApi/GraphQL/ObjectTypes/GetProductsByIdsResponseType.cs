using HotChocolate.Types;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetProductsByIds;

namespace SimpleStore.InventoriesApi.GraphQL.ObjectTypes
{
    public class GetProductsByIdsResponseType : ObjectType<GetProductsByIdsResponse>
    {
        #region Overrides of ObjectType<GetProductsByIdsResponse>

        protected override void Configure(IObjectTypeDescriptor<GetProductsByIdsResponse> descriptor)
        {
            descriptor.Name($"{nameof(ServiceOptions.InventoriesApi)}_{nameof(GetProductsByIdsResponse)}");
        }

        #endregion
    }
}
