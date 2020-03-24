using System;
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
using Microsoft.Extensions.Configuration;
using SimpleStore.Infra.RedisPubSub.Extensions;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Options;


namespace SimpleStore.ProductCatalog.Infrastructure.EfCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomInfrastructure(this IServiceCollection services, IConfiguration configuration)
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
            
            services.AddDomainEventDispatcher();
            services.AddRedisPubSub(configuration);

            services.AddHttpClient<InventoriesGateway>((provider, client) =>
            {
                var serviceOptions = provider.GetRequiredService<ServiceOptions>();
                client.BaseAddress = new Uri(serviceOptions.InventoriesApi.RestUri, UriKind.Absolute);
            });

            return services;
        }
    }
}
