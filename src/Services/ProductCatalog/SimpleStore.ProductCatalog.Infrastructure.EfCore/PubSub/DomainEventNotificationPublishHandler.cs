using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SimpleStore.Infrastructure.Common;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Options;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.PubSub
{
    public class DomainEventNotificationPublishHandler : INotificationHandler<DomainEventNotification>
    {
        private readonly ILogger<DomainEventNotificationPublishHandler> _logger;
        private readonly ServiceOptions _serviceOptions;
        private readonly IEventBus _eventBus;

        public DomainEventNotificationPublishHandler(ILogger<DomainEventNotificationPublishHandler> logger, IOptions<ServiceOptions> serviceOptions, IEventBus eventBus)
        {
            this._logger = logger;
            this._serviceOptions = serviceOptions.Value;
            this._eventBus = eventBus;
        }

        #region Implementation of INotificationHandler<in DomainEventNotification>

        public async Task Handle(DomainEventNotification notification, CancellationToken cancellationToken)
        {
            var toJson = JsonSerializer.Serialize(notification);

            await this._eventBus.PublishAsync(notification, this._serviceOptions.ProductCatalogApi.ServiceName);
            
            this._logger.LogInformation($"[{nameof(DomainEventNotificationPublishHandler)}]: Published notification - {notification}");
        }

        #endregion
    }
}
