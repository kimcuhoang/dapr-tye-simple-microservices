using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.UpdateProduct;
using SimpleStore.ProductCatalogApi.Options;

namespace SimpleStore.ProductCatalogApi.GraphQL.InputObjects
{
    public class UpdateProductRequestType : InputObjectType<UpdateProductRequest>
    {
        private readonly ServiceOptions _serviceOptions;

        public UpdateProductRequestType(IOptions<ServiceOptions> serviceOptions)
            => this._serviceOptions = serviceOptions.Value;

        #region Overrides of InputObjectType<UpdateProductRequest>

        protected override void Configure(IInputObjectTypeDescriptor<UpdateProductRequest> descriptor)
        {
            descriptor.Name($"{this._serviceOptions.ProductCatalogApi.ServiceName}_{nameof(UpdateProductRequest)}");
        }

        #endregion
    }
}
