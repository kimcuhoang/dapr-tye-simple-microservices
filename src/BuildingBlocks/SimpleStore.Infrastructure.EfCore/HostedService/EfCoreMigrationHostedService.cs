using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SimpleStore.Infrastructure.EfCore.HostedService
{
    public abstract class EfCoreMigrationHostedService<TDbContext> : IHostedService where TDbContext : ApplicationDbContextBase
    {
        private readonly IServiceProvider _serviceProvider;

        protected EfCoreMigrationHostedService(IServiceProvider serviceProvider)
            => this._serviceProvider = serviceProvider;

        #region Implementation of IHostedService

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = this._serviceProvider.CreateScope();

            var applicationDbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();

            await this.DoMigration(applicationDbContext);
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        #endregion

        protected abstract Task DoMigration(TDbContext dbContext);
    }
}
