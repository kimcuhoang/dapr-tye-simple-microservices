using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Options;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.GetProducts;

namespace SimpleStore.ProductCatalogApi.GraphQL.ObjectTypes
{
    public class GetProductsResponseType : ObjectType<GetProductsResponse>
    {
        private readonly ServiceOptions _serviceOptions;

        public GetProductsResponseType(IOptions<ServiceOptions> serviceOptions)
            => this._serviceOptions = serviceOptions.Value;

        #region Overrides of ObjectType<GetProductsResponse>

        protected override void Configure(IObjectTypeDescriptor<GetProductsResponse> descriptor)
        {
            descriptor.Name($"{this._serviceOptions.ProductCatalogApi.ServiceName}_{nameof(GetProductsResponse)}");
        }

        #endregion
    }
}
