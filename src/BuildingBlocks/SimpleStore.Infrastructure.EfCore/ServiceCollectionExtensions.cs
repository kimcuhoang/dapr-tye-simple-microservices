using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleStore.Infrastructure.Common.Tye;
using SimpleStore.Infrastructure.EfCore.HostedService;
using SimpleStore.Infrastructure.EfCore.Persistence;
using System.Reflection;

namespace SimpleStore.Infrastructure.EfCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfCore<TDbContext>(this IServiceCollection services,
                                                    IHealthChecksBuilder healthChecksBuilder,
                                                    IConfiguration configuration, 
                                                    Assembly fromAssembly) where TDbContext : DbContext
        {
            services
                .AddDbContext<DbContext, TDbContext>((provider, opts) =>
                {
                        var connectionString = configuration.GetConnectionString("default");
                        
                        if (configuration.IsTyeEnabled())
                        {
                            var databaseName = configuration.GetValue<string>("DatabaseName");
                            connectionString = configuration.GetConnectionString("sqlserver");
                            connectionString =
                                $"{connectionString};Initial Catalog={databaseName}";
                        }

                        opts.UseSqlServer(connectionString, context =>
                        {
                            context.MigrationsAssembly(fromAssembly.GetName().Name);
                            context.EnableRetryOnFailure(maxRetryCount: 3);
                        });
                    })
                .AddHostedService<EfCoreMigrationHostedService>()
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(PersistenceBehavior<,>));

            healthChecksBuilder.AddDbContextCheck<DbContext>();

            return services;
        }
    }
}
