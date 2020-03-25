using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.CreateProduct;

namespace SimpleStore.InventoriesApi.GraphQL.InputTypes
{
    public class CreateProductRequestType : InputObjectType<CreateProductRequest>
    {
        private readonly ServiceOptions _serviceOptions;

        public CreateProductRequestType(IOptions<ServiceOptions> serviceOptions)
            => this._serviceOptions = serviceOptions.Value;

        #region Overrides of InputObjectType<CreateProductRequest>

        protected override void Configure(IInputObjectTypeDescriptor<CreateProductRequest> descriptor)
        {
            descriptor.Name($"{this._serviceOptions.InventoriesApi.ServiceName}_{nameof(CreateProductRequest)}");
        }

        #endregion
    }
}
