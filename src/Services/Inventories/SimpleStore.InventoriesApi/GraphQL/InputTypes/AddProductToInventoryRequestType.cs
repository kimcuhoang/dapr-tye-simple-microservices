using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.AddProductToInventory;
using SimpleStore.InventoriesApi.Options;

namespace SimpleStore.InventoriesApi.GraphQL.InputTypes
{
    public class AddProductToInventoryRequestType : InputObjectType<AddProductToInventoryRequest>
    {
        private readonly ServiceOptions _serviceOptions;

        public AddProductToInventoryRequestType(IOptions<ServiceOptions> serviceOptions)
            => this._serviceOptions = serviceOptions.Value;

        #region Overrides of InputObjectType<AddProductToInventoryRequest>

        protected override void Configure(IInputObjectTypeDescriptor<AddProductToInventoryRequest> descriptor)
        {
            descriptor.Name($"{this._serviceOptions.InventoriesApi.ServiceName}_{nameof(AddProductToInventoryRequest)}");
        }

        #endregion
    }
}
