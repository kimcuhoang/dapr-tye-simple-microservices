using MediatR;
using Microsoft.Extensions.Logging;
using SimpleStore.Infrastructure.Common;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.PubSub
{
    public class ProductCreatedNotificationHandler : INotificationHandler<DomainEventNotification>
    {
        private readonly ILogger<ProductCreatedNotificationHandler> _logger;
        private readonly DaprProductCreatedPublisher _daprPublisher;

        public ProductCreatedNotificationHandler(ILogger<ProductCreatedNotificationHandler> logger, DaprProductCreatedPublisher daprPublisher)
        {
            this._logger = logger;
            this._daprPublisher = daprPublisher;
        }

        #region Implementation of INotificationHandler<in DomainEventNotification>

        public async Task Handle(DomainEventNotification notification, CancellationToken cancellationToken)
        {
            await this._daprPublisher.Publish(notification.DomainEvent, cancellationToken);

            this._logger.LogInformation($"[{nameof(ProductCreatedNotificationHandler)}]: Published notification - {notification}");
        }

        #endregion
    }
}
