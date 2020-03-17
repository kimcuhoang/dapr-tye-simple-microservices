using MediatR;
using Microsoft.Extensions.Logging;
using SimpleStore.Domain.Models;
using System.Threading.Tasks;

namespace SimpleStore.Infrastructure.Common
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DomainEventDispatcher> _logger;

        public DomainEventDispatcher(IMediator mediator, ILogger<DomainEventDispatcher> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }

        #region Implementation of IDomainEventDispatcher

        public async Task Dispatch(IDomainEvent @event)
        {
            this._logger.LogInformation($"Dispatching domain event: {@event.GetType().Name}");
            await this._mediator.Publish(new DomainEventNotification
            {
                DomainEvent = @event
            });
        }

        #endregion
    }
}
