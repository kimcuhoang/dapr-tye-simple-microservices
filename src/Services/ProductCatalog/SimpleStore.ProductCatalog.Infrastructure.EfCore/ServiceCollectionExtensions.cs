using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleStore.Infrastructure.EfCore;
using SimpleStore.Infrastructure.EfCore.HostedService;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Persistence;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.SqlServer;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.ValidationModel;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore
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
                .AddDbContext<ProductCatalogDbContext>((serviceProvider, dbContextOptionBuilder) =>
                {
                    var extendOptionsBuilder = serviceProvider.GetRequiredService<IExtendDbContextOptionsBuilder>();
                    var connStringFactory = serviceProvider.GetRequiredService<IConnectionStringFactory>();
                    extendOptionsBuilder.Extend(dbContextOptionBuilder, connStringFactory, string.Empty);
                })
                .AddScoped<DbContext>(serviceProvider => serviceProvider.GetRequiredService<ProductCatalogDbContext>());
            

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
                //.AddScoped(typeof(IPipelineBehavior<,>), typeof(PersistenceBehavior<,>));


            services.AddHostedService<EfCoreMigrationHostedService>();
            
            return services;
        }
    }
}
