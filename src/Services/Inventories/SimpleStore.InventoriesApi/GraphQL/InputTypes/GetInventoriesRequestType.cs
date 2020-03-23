using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetInventories;

namespace SimpleStore.InventoriesApi.GraphQL.InputTypes
{
    public class GetInventoriesRequestType : ObjectType<GetInventoriesRequest>
    {
        private readonly ServiceOptions _serviceOptions;

        public GetInventoriesRequestType(IOptions<ServiceOptions> serviceOptions)
            => this._serviceOptions = serviceOptions.Value;

        #region Overrides of ObjectType<GetInventoriesRequest>

        protected override void Configure(IObjectTypeDescriptor<GetInventoriesRequest> descriptor)
        {
            descriptor.Name($"{this._serviceOptions.InventoriesApi.ServiceName}_{nameof(GetInventoriesRequest)}");
        }

        #endregion
    }
}
