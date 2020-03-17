using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetProducts;
using SimpleStore.InventoriesApi.Options;

namespace SimpleStore.InventoriesApi.GraphQL.ObjectTypes
{
    public class GetProductsResponseType : ObjectType<GetProductsResponse>
    {
        private readonly ServiceOptions _serviceOptions;

        public GetProductsResponseType(IOptions<ServiceOptions> serviceOptions)
            => this._serviceOptions = serviceOptions.Value;

        #region Overrides of ObjectType<GetProductsResponse>

        protected override void Configure(IObjectTypeDescriptor<GetProductsResponse> descriptor)
        {
            descriptor.Name($"{this._serviceOptions.InventoriesApi.ServiceName}_{nameof(GetProductsResponse)}");
        }

        #endregion
    }
}
