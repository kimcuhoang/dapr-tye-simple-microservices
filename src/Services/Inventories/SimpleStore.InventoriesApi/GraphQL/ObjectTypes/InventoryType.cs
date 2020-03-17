using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.Dto;
using SimpleStore.InventoriesApi.Options;

namespace SimpleStore.InventoriesApi.GraphQL.ObjectTypes
{
    public class InventoryType : ObjectType<InventoryDto>
    {
        private readonly ServiceOptions _serviceOptions;

        public InventoryType(IOptions<ServiceOptions> serviceOptions)
            => this._serviceOptions = serviceOptions.Value;

        #region Overrides of ObjectType<InventoryDto>

        protected override void Configure(IObjectTypeDescriptor<InventoryDto> descriptor)
        {
            descriptor.Name($"{this._serviceOptions.InventoriesApi.ServiceName}_{nameof(InventoryDto)}");
        }

        #endregion
    }
}
