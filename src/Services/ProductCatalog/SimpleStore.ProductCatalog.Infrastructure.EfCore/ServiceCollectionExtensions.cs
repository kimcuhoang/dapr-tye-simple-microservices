using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SimpleStore.Infrastructure.Common.Extensions;
using SimpleStore.Infrastructure.EfCore;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Gateways;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Options;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Persistence;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.PubSub;
using System;
using System.Reflection;


namespace SimpleStore.ProductCatalog.Infrastructure.EfCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .Configure<ServiceOptions>(configuration.GetSection("Services"))
                .AddEfCore<ProductCatalogDbContext>(configuration, Assembly.GetExecutingAssembly())
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                .AddCustomRequestValidation()
                .AddDomainEventDispatcher();

            services.AddHttpClient<InventoriesGateway>((provider, client) =>
            {
                var serviceOptions = provider.GetRequiredService<IOptions<ServiceOptions>>();
                client.BaseAddress = new Uri(serviceOptions.Value.InventoriesApi.RestUri, UriKind.Absolute);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            
            services.AddHttpClient<DaprPublisher>((provider, client) =>
            {
                var daprPort = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT") ?? "3500";
                var baseAddress = $"http://localhost:{daprPort}";
                client.BaseAddress = new Uri(baseAddress);
            });

            return services;
        }
    }
}
