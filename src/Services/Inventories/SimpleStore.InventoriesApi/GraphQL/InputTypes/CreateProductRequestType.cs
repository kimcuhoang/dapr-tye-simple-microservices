using HotChocolate.Types;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.CreateProduct;

namespace SimpleStore.InventoriesApi.GraphQL.InputTypes
{
    public class CreateProductRequestType : InputObjectType<CreateProductRequest>
    {
    }
}
