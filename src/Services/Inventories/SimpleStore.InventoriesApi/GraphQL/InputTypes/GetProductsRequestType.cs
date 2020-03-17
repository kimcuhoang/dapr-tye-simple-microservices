using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetProducts;
using SimpleStore.InventoriesApi.Options;

namespace SimpleStore.InventoriesApi.GraphQL.InputTypes
{
    public class GetProductsRequestType : InputObjectType<GetProductsRequest>
    {
        private readonly ServiceOptions _serviceOptions;

        public GetProductsRequestType(IOptions<ServiceOptions> serviceOptions)
            => this._serviceOptions = serviceOptions.Value;

        #region Overrides of InputObjectType<GetProductsRequest>

        protected override void Configure(IInputObjectTypeDescriptor<GetProductsRequest> descriptor)
        {
            descriptor.Name($"{this._serviceOptions.InventoriesApi.ServiceName}_{nameof(GetProductsRequest)}");
        }

        #endregion
    }
}
