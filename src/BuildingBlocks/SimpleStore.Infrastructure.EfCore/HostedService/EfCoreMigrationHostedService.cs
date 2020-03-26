using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SimpleStore.Infrastructure.EfCore.SqlServer;

namespace SimpleStore.Infrastructure.EfCore.HostedService
{
    public class EfCoreMigrationHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<EfCoreMigrationHostedService> _logger;

        public EfCoreMigrationHostedService(IServiceProvider serviceProvider, ILogger<EfCoreMigrationHostedService> logger)
        {
            this._serviceProvider = serviceProvider;
            this._logger = logger;
        }

        #region Implementation of IHostedService

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = this._serviceProvider.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();

            var sqlServerConfig = scope.ServiceProvider.GetRequiredService<IOptions<SqlServerConfig>>()?.Value;
            this._logger.LogInformation($"{nameof(EfCoreMigrationHostedService)} - ConnectionString: {sqlServerConfig.ConnectionStrings}");

            await dbContext.Database.MigrateAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        #endregion
    }
}
