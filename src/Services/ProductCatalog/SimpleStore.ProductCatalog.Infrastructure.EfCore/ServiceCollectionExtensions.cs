using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SimpleStore.Infra.RedisPubSub.Extensions;
using SimpleStore.Infrastructure.Common.Extensions;
using SimpleStore.Infrastructure.EfCore;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Options;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Persistence;
using System;
using System.Reflection;


namespace SimpleStore.ProductCatalog.Infrastructure.EfCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEfCore<ProductCatalogDbContext>(configuration, Assembly.GetExecutingAssembly());

            services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddCustomRequestValidation();
            
            services.AddDomainEventDispatcher();
            services.AddRedisPubSub(configuration);

            services.Configure<ServiceOptions>(configuration.GetSection("Services"));
            services.AddHttpClient<InventoriesGateway>((provider, client) =>
            {
                var serviceOptions = provider.GetRequiredService<IOptions<ServiceOptions>>();
                client.BaseAddress = new Uri(serviceOptions.Value.InventoriesApi.RestUri, UriKind.Absolute);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            return services;
        }
    }
}
