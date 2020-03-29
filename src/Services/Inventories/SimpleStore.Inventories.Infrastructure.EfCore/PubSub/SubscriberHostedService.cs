using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SimpleStore.Infrastructure.Common;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SimpleStore.Inventories.Infrastructure.EfCore.UseCases.CreateProduct;

namespace SimpleStore.Inventories.Infrastructure.EfCore.PubSub
{
    public class SubscriberHostedService : IHostedService
    {
        private readonly ILogger<SubscriberHostedService> _logger;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly IEventBus _eventBus;
        private readonly IServiceProvider _serviceProvider;
        private readonly ServiceOptions _serviceOptions;

        public SubscriberHostedService(ILogger<SubscriberHostedService> logger, IHostApplicationLifetime hostApplicationLifetime, IEventBus eventBus, IServiceProvider serviceProvider, IOptions<ServiceOptions> serviceOptions)
        {
            this._logger = logger;
            this._hostApplicationLifetime = hostApplicationLifetime;
            this._eventBus = eventBus;
            this._serviceProvider = serviceProvider;
            this._serviceOptions = serviceOptions.Value;
        }

        #region Implementation of IHostedService

        public  Task StartAsync(CancellationToken cancellationToken)
        {
            var productCatalogChannel = this._serviceOptions.ProductCatalogApi.ServiceName;

            this._hostApplicationLifetime.ApplicationStarted.Register(() =>
            {
                this._logger.LogInformation($"{nameof(SubscriberHostedService)} - OnStarted has been called.");

                this._eventBus.SubscribeAsync(async (channel, message) =>
                {
                    this._logger.LogInformation($"{nameof(SubscriberHostedService)} - receive {message}");

                    var msg = JsonSerializer.Deserialize<CreateProductRequest>((string)message);

                    using var scope = this._serviceProvider.CreateScope();
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                    await mediator.Send(msg, cancellationToken);

                }, productCatalogChannel).Wait(cancellationToken);
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this._hostApplicationLifetime.ApplicationStopped.Register(() =>
            {
                this._logger.LogInformation($"{nameof(SubscriberHostedService)} - OnStopped has been called.");
                if (this._eventBus != null)
                {
                    GC.SuppressFinalize(this._eventBus);
                }
            });
            return Task.CompletedTask;
        }
        
        #endregion
    }
}
