using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.CreateProduct;

namespace SimpleStore.InventoriesApi.GraphQL.ObjectTypes
{
    public class CreateProductResponseType : ObjectType<CreateProductResponse>
    {
        private readonly ServiceOptions _serviceOptions;

        public CreateProductResponseType(IOptions<ServiceOptions> serviceOptions)
            => this._serviceOptions = serviceOptions.Value;

        #region Overrides of ObjectType<CreateProductResponse>

        protected override void Configure(IObjectTypeDescriptor<CreateProductResponse> descriptor)
        {
            descriptor.Name($"{this._serviceOptions.InventoriesApi.ServiceName}_{nameof(CreateProductResponse)}");
        }

        #endregion
    }
}
