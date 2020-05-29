using System;
using Microsoft.Extensions.Configuration;
using SimpleStore.Infrastructure.Common.Options;

namespace SimpleStore.Infrastructure.Common.Tye
{
    public static class TyeConfigurationExtensions
    {
        public static bool EnabledTye(this IConfiguration configuration)
            => Convert.ToBoolean(configuration["EnabledTye"]);

        public static Uri GetCustomServiceUri(this IConfiguration configuration, ServiceConfig serviceConfig)
            => configuration.EnabledTye()
                ? configuration.GetServiceUri(serviceConfig.ServiceName)
                : new Uri(serviceConfig.RestUri);
    }
}
