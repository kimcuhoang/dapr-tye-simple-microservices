using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleStore.Infra.RedisPubSub.Extensions;
using SimpleStore.Infrastructure.Common.Extensions;
using SimpleStore.Infrastructure.EfCore;
using SimpleStore.Inventories.Infrastructure.EfCore.Persistence;
using SimpleStore.Inventories.Infrastructure.EfCore.PubSub;
using System.Reflection;
using SimpleStore.Inventories.Infrastructure.EfCore.Options;

namespace SimpleStore.Inventories.Infrastructure.EfCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ServiceOptions>(configuration.GetSection("Services"));
            services.AddEfCore<InventoryDbContext>(configuration, Assembly.GetExecutingAssembly());

            services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddCustomRequestValidation();

            services
                .AddDomainEventDispatcher()
                .AddRedisPubSub(configuration)
                .AddHostedService<SubscriberHostedService>();

            return services;
        }
    }
}
