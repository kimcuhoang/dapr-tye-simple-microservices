using HotChocolate.Types;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetProductsByIds;

namespace SimpleStore.InventoriesApi.GraphQL.InputTypes
{
    public class GetProductsByIdsRequestType : InputObjectType<GetProductsByIdsRequest>
    {
        #region Overrides of InputObjectType<GetProductsByIdsRequest>

        protected override void Configure(IInputObjectTypeDescriptor<GetProductsByIdsRequest> descriptor)
        {
            descriptor.Name($"{nameof(ServiceOptions.InventoriesApi)}_{nameof(GetProductsByIdsRequest)}");
        }

        #endregion
    }
}
