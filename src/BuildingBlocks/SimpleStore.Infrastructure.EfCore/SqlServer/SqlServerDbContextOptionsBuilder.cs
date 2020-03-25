using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleStore.Infrastructure.EfCore.Persistence;

namespace SimpleStore.Infrastructure.EfCore.SqlServer
{
    public class SqlServerDbContextOptionsBuilder : IExtendDbContextOptionsBuilder
    {
        private readonly ILogger<SqlServerDbContextOptionsBuilder> _logger;
        private readonly IConnectionStringFactory _connectionStringFactory;

        public SqlServerDbContextOptionsBuilder(IConnectionStringFactory connectionStringFactory, ILogger<SqlServerDbContextOptionsBuilder> logger)
        {
            this._connectionStringFactory = connectionStringFactory;
            this._logger = logger;
        }

        #region Implementation of IExtendDbContextOptionsBuilder

        public DbContextOptionsBuilder Extend(DbContextOptionsBuilder optionsBuilder, IConnectionStringFactory connectionStringFactory, string assemblyName = null)
        {
            var connectionString = this._connectionStringFactory.Create();
            this._logger.LogInformation(connectionString);
            return optionsBuilder.UseSqlServer(this._connectionStringFactory.Create(), opts =>
                {
                    opts.MigrationsAssembly(assemblyName);
                    opts.EnableRetryOnFailure(maxRetryCount: 3);
                });
        }

        #endregion
    }
}
