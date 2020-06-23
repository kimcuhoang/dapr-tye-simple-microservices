using Dapr.Client;
using Dapr.Client.Http;
using Microsoft.Extensions.Options;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways.UseCases.GetProductsByIds;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Options;
using System.Threading;
using System.Threading.Tasks;
using HTTPExtension = Dapr.Client.Http.HTTPExtension;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways
{
    public class DaprInventoriesGateway
    {
        private readonly ServiceOptions _serviceOptions;
        private readonly DaprClient _daprClient;

        private string InventoryAppId => this._serviceOptions.InventoriesApi.ServiceName;

        private HTTPExtension httpExtension => new HTTPExtension
        {
            Verb = HTTPVerb.Post
        };

        public DaprInventoriesGateway(DaprClient daprClient, IOptions<ServiceOptions> serviceOptions)
        {
            this._daprClient = daprClient;
            this._serviceOptions = serviceOptions.Value;
        }

        public async Task<GetProductsByIdsResponse> GetProductsByIds(GetProductsByIdsRequest request, CancellationToken cancellationToken = default(CancellationToken))
            => await this._daprClient.InvokeMethodAsync<GetProductsByIdsRequest, GetProductsByIdsResponse>(this.InventoryAppId, 
                                                                                                            "api/products/get-by-ids", 
                                                                                                            request, 
                                                                                                            this.httpExtension, 
                                                                                                            cancellationToken);
    }
}
