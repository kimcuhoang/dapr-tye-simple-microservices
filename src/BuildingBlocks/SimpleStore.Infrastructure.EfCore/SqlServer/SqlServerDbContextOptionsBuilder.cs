using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Infrastructure.EfCore.Persistence;

namespace SimpleStore.Infrastructure.EfCore.SqlServer
{
    public class SqlServerDbContextOptionsBuilder : IExtendDbContextOptionsBuilder
    {
        private readonly IConnectionStringFactory _connectionStringFactory;

        public SqlServerDbContextOptionsBuilder(IConnectionStringFactory connectionStringFactory)
        {
            this._connectionStringFactory = connectionStringFactory;
        }

        #region Implementation of IExtendDbContextOptionsBuilder

        public DbContextOptionsBuilder Extend(DbContextOptionsBuilder optionsBuilder, IConnectionStringFactory connectionStringFactory, string assemblyName = null)
        {
            return optionsBuilder.UseSqlServer(this._connectionStringFactory.Create(), opts =>
                {
                    opts.MigrationsAssembly(assemblyName);
                    opts.EnableRetryOnFailure(maxRetryCount: 3);
                });
        }

        #endregion
    }
}
