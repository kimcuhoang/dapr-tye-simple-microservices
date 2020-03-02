using Microsoft.Extensions.Options;
using SimpleStore.Infrastructure.EfCore;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.SqlServer
{
    public class SqlServerConnectionStringFactory : IConnectionStringFactory
    {
        private readonly SqlServerConfig _sqlServerConfig;

        public SqlServerConnectionStringFactory(IOptions<SqlServerConfig> sqlServerConfig)
            => this._sqlServerConfig = sqlServerConfig.Value;

        #region Implementation of IConnectionStringFactory

        public string Create()
            => $"Server={this._sqlServerConfig.Server};Database={this._sqlServerConfig.DatabaseName};User ID={this._sqlServerConfig.AccountName};Password={this._sqlServerConfig.AccountPassword};MultipleActiveResultSets=true";

        #endregion
    }
}
