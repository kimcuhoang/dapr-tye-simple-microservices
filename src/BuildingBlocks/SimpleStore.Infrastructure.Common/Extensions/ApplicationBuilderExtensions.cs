using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.DependencyInjection;
using SimpleStore.Infrastructure.Common.Options;

namespace SimpleStore.Infrastructure.Common.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder Listen(this IApplicationBuilder app, ServiceConfig serviceConfig)
        {
            var serverFeatures = app.ApplicationServices.GetRequiredService<IServer>().Features;
            var addresses = serverFeatures.Get<IServerAddressesFeature>().Addresses;
            addresses.Clear();
            addresses.Add(serviceConfig.RestUri);
            return app;
        }
    }
}
