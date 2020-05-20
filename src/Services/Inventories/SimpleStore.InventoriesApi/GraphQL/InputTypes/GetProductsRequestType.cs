using HotChocolate.Types;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetProducts;

namespace SimpleStore.InventoriesApi.GraphQL.InputTypes
{
    public class GetProductsRequestType : InputObjectType<GetProductsRequest>
    {
        #region Overrides of InputObjectType<GetProductsRequest>

        protected override void Configure(IInputObjectTypeDescriptor<GetProductsRequest> descriptor)
        {
            descriptor.Name($"{nameof(ServiceOptions.InventoriesApi)}_{nameof(GetProductsRequest)}");
        }

        #endregion
    }
}
