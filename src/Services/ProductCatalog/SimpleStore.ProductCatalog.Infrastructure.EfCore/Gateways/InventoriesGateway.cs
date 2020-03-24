using SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways
{
    public class InventoriesGateway
    {
        private readonly HttpClient _httpClient;

        public InventoriesGateway(HttpClient httpClient)
            => this._httpClient = httpClient;

        public async Task<GetInventoriesResponse> GetInventories(GetInventoriesRequest request)
        {
            var response = await this._httpClient.GetAsync("/inventories");
            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<GetInventoriesResponse>(result);
        }
    }
}
