using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleStore.Infrastructure.Common.Extensions;
using SimpleStore.Infrastructure.EfCore;
using SimpleStore.Infrastructure.EfCore.Persistence;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Persistence;
using System.Reflection;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomInfrastructure(this IServiceCollection services)
        {
            services
                .AddEfCore()
                .AddDbContext<ProductCatalogDbContext>((serviceProvider, dbContextOptionBuilder) =>
                {
                    var extendOptionsBuilder = serviceProvider.GetRequiredService<IExtendDbContextOptionsBuilder>();
                    var connStringFactory = serviceProvider.GetRequiredService<IConnectionStringFactory>();
                    extendOptionsBuilder.Extend(dbContextOptionBuilder, connStringFactory, Assembly.GetExecutingAssembly().GetName().Name);
                })
                .AddScoped<DbContext>(serviceProvider => serviceProvider.GetRequiredService<ProductCatalogDbContext>())
                .AddCustomHostedServices();

            services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddCustomRequestValidation();

            return services;
        }
    }
}
