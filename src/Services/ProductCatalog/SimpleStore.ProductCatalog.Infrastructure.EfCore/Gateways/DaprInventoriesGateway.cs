using SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Options;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways
{
    public class DaprInventoriesGateway
    {
        private readonly HttpClient _httpClient;
        private readonly ServiceOptions _serviceOptions;

        public DaprInventoriesGateway(HttpClient httpClient, IOptions<ServiceOptions> serviceOptions)
        {
            this._httpClient = httpClient;
            this._serviceOptions = serviceOptions.Value;
        } 

        public async Task<GetInventoriesResponse> GetInventories(GetInventoriesRequest request)
        {
            var content = JsonSerializer.Serialize(request, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            var requestStringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await this._httpClient.PostAsync($"/v1.0/invoke/{this._serviceOptions.InventoriesApi.ServiceName}/method/get-list", requestStringContent);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<GetInventoriesResponse>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
