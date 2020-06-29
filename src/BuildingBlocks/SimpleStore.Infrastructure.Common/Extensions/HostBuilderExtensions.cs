using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SimpleStore.Infrastructure.Common.Options;
using System;

namespace SimpleStore.Infrastructure.Common.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder CustomConfigure(this IHostBuilder hostBuilder, Type startupType, Func<IConfiguration, ServiceConfig> getServiceConfigFn)
        {
            hostBuilder
                .ConfigureWebHostDefaults(webBuilder => {
                                webBuilder
                                    .UseStartup(startupType)
                                    .CaptureStartupErrors(true)
                                    .AddCustomAppConfiguration();
                            })
                .UseDefaultServiceProvider((context, options) => {
                                options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                                options.ValidateOnBuild = true;
                            });

            return hostBuilder;
        }

    }
}
