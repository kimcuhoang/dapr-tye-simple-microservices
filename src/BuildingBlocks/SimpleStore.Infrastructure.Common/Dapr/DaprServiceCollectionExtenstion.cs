using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace SimpleStore.Infrastructure.Common.Dapr
{
    public static class DaprServiceCollectionExtenstion
    {
        public static IServiceCollection AddCustomDapr(this IServiceCollection services)
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            services.AddDaprClient(client =>
            {
                client.UseJsonSerializationOptions(options);
            });

            return services;
        }
    }
}
