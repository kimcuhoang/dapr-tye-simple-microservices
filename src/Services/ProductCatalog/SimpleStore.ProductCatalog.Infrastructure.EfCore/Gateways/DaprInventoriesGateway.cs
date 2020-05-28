using Dapr.Client;
using Dapr.Client.Http;
using Microsoft.Extensions.Options;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways.Models;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Options;
using System.Threading.Tasks;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways
{
    public class DaprInventoriesGateway
    {
        private readonly ServiceOptions _serviceOptions;
        private readonly DaprClient _daprClient;

        public DaprInventoriesGateway(DaprClient daprClient, IOptions<ServiceOptions> serviceOptions)
        {
            this._daprClient = daprClient;
            this._serviceOptions = serviceOptions.Value;
        } 

        public async Task<GetInventoriesResponse> GetInventories(GetInventoriesRequest request)
        {
            var httpExtension = new HTTPExtension
            {
                Verb = HTTPVerb.Post
            };

            var appId = this._serviceOptions.InventoriesApi.ServiceName;

            var response = await this._daprClient.InvokeMethodAsync<GetInventoriesRequest, GetInventoriesResponse>(appId, "get-list", request, httpExtension);

            return response;
        }
    }
}
