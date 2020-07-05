using Microsoft.Extensions.Configuration;
using SimpleStore.Infrastructure.Common.Options;
using System;

namespace SimpleStore.Infrastructure.Common.Tye
{
    public static class TyeExtensions
    {
        public static bool IsTyeEnabled(this IConfiguration configuration)
            => configuration.GetValue<bool>("EnabledTye");

        public static Uri GetServiceUriFor(this IConfiguration configuration, ServiceConfig serviceConfig)
            => configuration.IsTyeEnabled()
                ? configuration.GetServiceUri(serviceConfig.ServiceName)
                : new Uri(serviceConfig.ServiceUrl);
    }
}
