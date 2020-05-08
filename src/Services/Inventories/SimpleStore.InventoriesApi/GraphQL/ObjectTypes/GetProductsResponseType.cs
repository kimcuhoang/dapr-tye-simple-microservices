using HotChocolate.Types;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetProducts;

namespace SimpleStore.InventoriesApi.GraphQL.ObjectTypes
{
    public class GetProductsResponseType : ObjectType<GetProductsResponse>
    {
        #region Overrides of ObjectType<GetProductsResponse>

        protected override void Configure(IObjectTypeDescriptor<GetProductsResponse> descriptor)
        {
            descriptor.Name($"{nameof(ServiceOptions.InventoriesApi)}_{nameof(GetProductsResponse)}");
        }

        #endregion
    }
}
