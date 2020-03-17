using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.AddOrUpdateProductInventory;
using SimpleStore.InventoriesApi.Options;

namespace SimpleStore.InventoriesApi.GraphQL.InputTypes
{
    public class AddOrUpdateProductInventoryRequestType : InputObjectType<AddOrdUpdateProductInventoryRequest>
    {
        private readonly ServiceOptions _serviceOptions;

        public AddOrUpdateProductInventoryRequestType(IOptions<ServiceOptions> serviceOptions)
            => this._serviceOptions = serviceOptions.Value;

        #region Overrides of InputObjectType<AddProductToInventoryRequest>

        protected override void Configure(IInputObjectTypeDescriptor<AddOrdUpdateProductInventoryRequest> descriptor)
        {
            descriptor.Name($"{this._serviceOptions.InventoriesApi.ServiceName}_{nameof(AddOrdUpdateProductInventoryRequest)}");
        }

        #endregion
    }
}
