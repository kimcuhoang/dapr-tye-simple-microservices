using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleStore.Infrastructure.EfCore.HostedService
{
    public class EfCoreMigrationHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public EfCoreMigrationHostedService(IServiceProvider serviceProvider)
            => this._serviceProvider = serviceProvider;

        #region Implementation of IHostedService

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = this._serviceProvider.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();

            await dbContext.Database.MigrateAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        #endregion
    }
}
