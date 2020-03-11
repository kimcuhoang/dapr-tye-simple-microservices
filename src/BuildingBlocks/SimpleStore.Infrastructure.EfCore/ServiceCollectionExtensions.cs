using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleStore.Infrastructure.EfCore.HostedService;
using SimpleStore.Infrastructure.EfCore.Persistence;
using SimpleStore.Infrastructure.EfCore.SqlServer;

namespace SimpleStore.Infrastructure.EfCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfCore(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var configuration = provider.GetRequiredService<IConfiguration>();

            services.Configure<SqlServerConfig>(options => configuration.GetSection("DatabaseInformation").Bind(options));

            services
                .AddSingleton<IConnectionStringFactory, SqlServerConnectionStringFactory>()
                .AddSingleton<IExtendDbContextOptionsBuilder, SqlServerDbContextOptionsBuilder>()
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(PersistenceBehavior<,>));

            return services;
        }

        public static IServiceCollection AddCustomHostedServices(this IServiceCollection services)
        {
            services.AddHostedService<EfCoreMigrationHostedService>();
            return services;
        }
    }
}
