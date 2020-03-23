using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SimpleStore.Infra.RedisPubSub.Options;
using SimpleStore.Infrastructure.Common;

namespace SimpleStore.Infra.RedisPubSub.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRedisPubSub(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .Configure<RedisOptions>(configuration.GetSection("Redis"))
                .AddSingleton<RedisStore>();

            services.Replace(ServiceDescriptor.Singleton<IEventBus, RedisEventBus>());

            return services;
        }
    }
}
