using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SimpleStore.Infrastructure.EfCore.HostedService;
using SimpleStore.Infrastructure.EfCore.Persistence;
using SimpleStore.Infrastructure.EfCore.SqlServer;
using System.Reflection;

namespace SimpleStore.Infrastructure.EfCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfCore<TDbContext>(this IServiceCollection services, IConfiguration configuration, Assembly fromAssembly) where TDbContext : DbContext
        {
            services
                .Configure<SqlServerConfig>(configuration.GetSection("DatabaseInformation"));
            
            services
                .AddDbContext<DbContext, TDbContext>((provider, opts) =>
                    {
                        var sqlServerConfig = provider.GetRequiredService<IOptions<SqlServerConfig>>()?.Value;
                        opts.UseSqlServer(sqlServerConfig.ConnectionStrings, context =>
                        {
                            context.MigrationsAssembly(fromAssembly.GetName().Name);
                            context.EnableRetryOnFailure(maxRetryCount: 3);
                        });
                    })
                .AddHostedService<EfCoreMigrationHostedService>()
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(PersistenceBehavior<,>));

            return services;
        }
    }
}
