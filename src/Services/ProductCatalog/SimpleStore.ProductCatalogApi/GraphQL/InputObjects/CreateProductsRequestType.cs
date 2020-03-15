using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.CreateProduct;
using SimpleStore.ProductCatalogApi.Options;

namespace SimpleStore.ProductCatalogApi.GraphQL.InputObjects
{
    public class CreateProductsRequestType : InputObjectType<CreateProductRequest>
    {
        private readonly ServiceOptions _serviceOptions;

        public CreateProductsRequestType(IOptions<ServiceOptions> serviceOptions)
            => this._serviceOptions = serviceOptions.Value;

        #region Overrides of InputObjectType<CreateProductRequest>

        protected override void Configure(IInputObjectTypeDescriptor<CreateProductRequest> descriptor)
        {
            descriptor.Name($"{this._serviceOptions.ProductCatalogApi.ServiceName}_{nameof(CreateProductRequest)}");
        }

        #endregion
    }
}
