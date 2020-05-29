using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleStore.Infrastructure.Common.Options;
using SimpleStore.Infrastructure.Common.Tye;

namespace SimpleStore.Infrastructure.Common.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder Listen(this IApplicationBuilder app, IConfiguration configuration, ServiceConfig serviceConfig)
        {
            if (!configuration.EnabledTye())
            {
                var serverFeatures = app.ApplicationServices.GetRequiredService<IServer>().Features;
                var addresses = serverFeatures.Get<IServerAddressesFeature>().Addresses;
                addresses.Clear();
                addresses.Add(serviceConfig.RestUri);
            }
            return app;
        }
    }
}
