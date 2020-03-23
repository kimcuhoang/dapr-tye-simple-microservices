using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Dto;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Options;

namespace SimpleStore.ProductCatalogApi.GraphQL.ObjectTypes
{
    public class ProductType : ObjectType<ProductDto>
    {
        private readonly ServiceOptions _serviceOptions;

        public ProductType(IOptions<ServiceOptions> serviceOptions)
            => this._serviceOptions = serviceOptions.Value;

        #region Overrides of ObjectType<Product>

        protected override void Configure(IObjectTypeDescriptor<ProductDto> descriptor)
        {
            descriptor.Name($"{this._serviceOptions.ProductCatalogApi.ServiceName}_{nameof(ProductDto)}");
        }

        #endregion
    }
}
