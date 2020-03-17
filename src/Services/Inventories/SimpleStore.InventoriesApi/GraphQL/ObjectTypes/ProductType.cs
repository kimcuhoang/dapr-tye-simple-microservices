using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.Dto;
using SimpleStore.InventoriesApi.Options;

namespace SimpleStore.InventoriesApi.GraphQL.ObjectTypes
{
    public class ProductType : ObjectType<ProductDto>
    {
        private readonly ServiceOptions _serviceOptions;

        public ProductType(IOptions<ServiceOptions> serviceOptions)
            => this._serviceOptions = serviceOptions.Value;

        #region Overrides of ObjectType<ProductDto>

        protected override void Configure(IObjectTypeDescriptor<ProductDto> descriptor)
        {
            descriptor.Name($"{this._serviceOptions.InventoriesApi.ServiceName}_{nameof(ProductDto)}");
        }

        #endregion
    }
}
