using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.GetProducts;
using SimpleStore.ProductCatalogApi.Options;

namespace SimpleStore.ProductCatalogApi.GraphQL.InputObjects
{
    public class GetProductsRequestType : InputObjectType<GetProductsRequest>
    {
        private readonly ServiceOptions _serviceOptions;

        public GetProductsRequestType(IOptions<ServiceOptions> serviceOptions)
            => this._serviceOptions = serviceOptions.Value;

        #region Overrides of InputObjectType<GetProductsRequest>

        protected override void Configure(IInputObjectTypeDescriptor<GetProductsRequest> descriptor)
        {
            descriptor.Name($"{this._serviceOptions.ProductCatalogApi.ServiceName}_{nameof(GetProductsRequest)}");
        }

        #endregion
    }
}
