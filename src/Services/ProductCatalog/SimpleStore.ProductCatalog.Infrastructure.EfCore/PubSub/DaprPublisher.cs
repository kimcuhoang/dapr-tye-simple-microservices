using SimpleStore.Domain.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.PubSub
{
    public class DaprPublisher
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DaprPublisher> _logger;

        private const string Channel = "ProductCreated";

        public DaprPublisher(HttpClient httpClient, ILogger<DaprPublisher> logger)
        {
            this._httpClient = httpClient;
            this._logger = logger;
        }

        public async Task Publish(IDomainEvent @event, CancellationToken cancellationToken)
        {
            var jsonContent = JsonSerializer.Serialize(@event, @event.GetType(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            this._logger.LogInformation($"[{nameof(DaprPublisher)}] - Prepare to publish: {jsonContent}");

            var requestStringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await this._httpClient.PostAsync($"/v1.0/publish/{Channel}", requestStringContent, cancellationToken);

            response.EnsureSuccessStatusCode();

            this._logger.LogInformation($"[{nameof(DaprPublisher)}] - Published: {jsonContent}");
        }
    }
}
