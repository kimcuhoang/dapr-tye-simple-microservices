using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.AddProductToInventory;
using SimpleStore.InventoriesApi.Options;

namespace SimpleStore.InventoriesApi.GraphQL.ObjectTypes
{
    public class AddProductToInventoryResponseType : ObjectType<AddProductToInventoryResponse>
    {
        private readonly ServiceOptions _serviceOptions;

        public AddProductToInventoryResponseType(IOptions<ServiceOptions> serviceOptions)
            => this._serviceOptions = serviceOptions.Value;

        #region Overrides of ObjectType<AddProductToInventoryResponse>

        protected override void Configure(IObjectTypeDescriptor<AddProductToInventoryResponse> descriptor)
        {
            descriptor.Name($"{this._serviceOptions.InventoriesApi.ServiceName}_{nameof(AddProductToInventoryResponse)}");
        }

        #endregion
    }
}
