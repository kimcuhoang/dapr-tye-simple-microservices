using Microsoft.EntityFrameworkCore;
using SimpleStore.Infrastructure.EfCore.HostedService;
using System;
using System.Threading.Tasks;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Persistence;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.SqlServer
{
    public class SqlServerMigrationHostedService : EfCoreMigrationHostedService<ProductCatalogDbContext>
    {
        public SqlServerMigrationHostedService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        #region Overrides of EfCoreMigrationHostedService<ProductCatalogDbContext>

        protected override async Task DoMigration(ProductCatalogDbContext dbContext)
            => await dbContext.Database.MigrateAsync();

        #endregion
    }
}
