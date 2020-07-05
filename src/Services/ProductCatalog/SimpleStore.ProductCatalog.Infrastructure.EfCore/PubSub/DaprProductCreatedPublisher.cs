using System;
using Dapr.Client;
using Microsoft.Extensions.Logging;
using SimpleStore.Domain.Models;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.PubSub
{
    public class DaprProductCreatedPublisher
    {
        private readonly ILogger<DaprProductCreatedPublisher> _logger;
        private readonly DaprClient _daprClient;

        private const string Channel = "ProductCreated";

        public DaprProductCreatedPublisher(DaprClient daprClient, ILogger<DaprProductCreatedPublisher> logger)
        {
            this._daprClient = daprClient;
            this._logger = logger;
        }

        public async Task Publish(IDomainEvent @event, CancellationToken cancellationToken)
        {
            var jsonContent = JsonSerializer.Serialize(@event, @event.GetType(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            this._logger.LogInformation($"[{nameof(DaprProductCreatedPublisher)}] - Prepare to publish: {jsonContent}");

            await this._daprClient.PublishEventAsync(Channel, Convert.ChangeType(@event, @event.GetType()), cancellationToken);

            this._logger.LogInformation($"[{nameof(DaprProductCreatedPublisher)}] - Published: {jsonContent}");
        }
    }
}
