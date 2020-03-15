using HotChocolate.Types;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetProducts;

namespace SimpleStore.InventoriesApi.GraphQL.InputTypes
{
    public class GetProductsRequestType : InputObjectType<GetProductsRequest>
    {
    }
}
