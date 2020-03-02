using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleStore.Infrastructure.EfCore;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.SqlServer;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfCore(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var configuration = provider.GetRequiredService<IConfiguration>();

            services.Configure<SqlServerConfig>(options => configuration.GetSection("DatabaseInformation").Bind(options));

            services.AddSingleton<IConnectionStringFactory, SqlServerConnectionStringFactory>();
            services.AddSingleton<IExtendDbContextOptionsBuilder, SqlServerDbContextOptionsBuilder>();
            services.AddDbContext<ProductCatalogDbContext>((serviceProvider, dbContextOptionBuilder) =>
            {
                var extendOptionsBuilder = serviceProvider.GetRequiredService<IExtendDbContextOptionsBuilder>();
                var connStringFactory = serviceProvider.GetRequiredService<IConnectionStringFactory>();
                extendOptionsBuilder.Extend(dbContextOptionBuilder, connStringFactory, string.Empty);
            });

            services.AddHostedService<SqlServerMigrationHostedService>();
            
            return services;
        }
    }
}
