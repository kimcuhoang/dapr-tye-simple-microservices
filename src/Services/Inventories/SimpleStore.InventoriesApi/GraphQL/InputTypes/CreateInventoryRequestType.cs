using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.CreateInventory;
using SimpleStore.InventoriesApi.Options;

namespace SimpleStore.InventoriesApi.GraphQL.InputTypes
{
    public class CreateInventoryRequestType : InputObjectType<CreateInventoryRequest>
    {
        private readonly ServiceOptions _serviceOptions;

        public CreateInventoryRequestType(IOptions<ServiceOptions> serviceOptions)
        {
            this._serviceOptions = serviceOptions.Value;
        }

        #region Overrides of InputObjectType<CreateInventoryRequest>

        protected override void Configure(IInputObjectTypeDescriptor<CreateInventoryRequest> descriptor)
        {
            descriptor.Name($"{this._serviceOptions.InventoriesApi.ServiceName}_{nameof(CreateInventoryRequest)}");
        }

        #endregion
    }
}
