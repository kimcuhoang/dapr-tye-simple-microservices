using MediatR;
using Microsoft.Extensions.Logging;
using SimpleStore.Infrastructure.Common;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.PubSub
{
    public class DomainEventNotificationPublishHandler : INotificationHandler<DomainEventNotification>
    {
        private readonly ILogger<DomainEventNotificationPublishHandler> _logger;
        private readonly DaprPublisher _daprPublisher;

        public DomainEventNotificationPublishHandler(ILogger<DomainEventNotificationPublishHandler> logger, DaprPublisher daprPublisher)
        {
            this._logger = logger;
            this._daprPublisher = daprPublisher;
        }

        #region Implementation of INotificationHandler<in DomainEventNotification>

        public async Task Handle(DomainEventNotification notification, CancellationToken cancellationToken)
        {
            var toJson = JsonSerializer.Serialize(notification);

            await this._daprPublisher.Publish(notification.DomainEvent, cancellationToken);

            this._logger.LogInformation($"[{nameof(DomainEventNotificationPublishHandler)}]: Published notification - {notification}");
        }

        #endregion
    }
}
