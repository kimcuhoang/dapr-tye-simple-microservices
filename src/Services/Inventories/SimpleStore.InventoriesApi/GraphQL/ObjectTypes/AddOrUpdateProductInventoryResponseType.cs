using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.AddOrUpdateProductInventory;

namespace SimpleStore.InventoriesApi.GraphQL.ObjectTypes
{
    public class AddOrUpdateProductInventoryResponseType : ObjectType<AddOrUpdateProductInventoryResponse>
    {
        private readonly ServiceOptions _serviceOptions;

        public AddOrUpdateProductInventoryResponseType(IOptions<ServiceOptions> serviceOptions)
            => this._serviceOptions = serviceOptions.Value;

        #region Overrides of ObjectType<AddProductToInventoryResponse>

        protected override void Configure(IObjectTypeDescriptor<AddOrUpdateProductInventoryResponse> descriptor)
        {
            descriptor.Name($"{this._serviceOptions.InventoriesApi.ServiceName}_{nameof(AddOrUpdateProductInventoryResponse)}");
        }

        #endregion
    }
}
