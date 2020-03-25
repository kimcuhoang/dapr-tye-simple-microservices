using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetInventories;

namespace SimpleStore.InventoriesApi.GraphQL.ObjectTypes
{
    public class GetInventoriesResponseType : ObjectType<GetInventoriesResponse>
    {
        private readonly ServiceOptions _serviceOptions;

        public GetInventoriesResponseType(IOptions<ServiceOptions> serviceOptions)
            => this._serviceOptions = serviceOptions.Value;

        #region Overrides of ObjectType<GetInventoriesResponse>

        protected override void Configure(IObjectTypeDescriptor<GetInventoriesResponse> descriptor)
        {
            descriptor.Name($"{this._serviceOptions.InventoriesApi.ServiceName}_{nameof(GetInventoriesResponse)}");
        }

        #endregion
    }
}
