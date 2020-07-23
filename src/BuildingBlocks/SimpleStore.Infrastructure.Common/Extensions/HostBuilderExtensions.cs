using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SimpleStore.Infrastructure.Common.Options;
using SimpleStore.Infrastructure.Common.Tye;
using System;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace SimpleStore.Infrastructure.Common.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder CustomConfigWebHostFor(this IHostBuilder hostBuilder,
                                                        ServiceConfig mainService,
                                                        Type startupType, 
                                                        IConfiguration configuration,
                                                        CommonServiceOptions serviceOptions)
        {
            hostBuilder.ConfigureWebHostDefaults(webHostBuilder =>
            {
                webHostBuilder
                    .UseStartup(startupType)
                    .CaptureStartupErrors(true)
                    .ConfigureAppConfiguration((context, configurationBuilder) =>
                    {
                        configurationBuilder.AddConfiguration(configuration);
                    });

                webHostBuilder.ConfigureKestrel((context, kestrelOptions) =>
                {
                    var serviceUri = configuration.GetServiceUriFor(mainService);

                    kestrelOptions.ListenAnyIP(serviceUri.Port, listenOptions =>
                    {
                        listenOptions.UseConnectionLogging();
                    });
                });
            });


            hostBuilder.UseDefaultServiceProvider((context, options) =>
            {
                options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                options.ValidateOnBuild = true;
            });

            if (!configuration.IsTyeEnabled())
            {
                var seqServiceConfig = serviceOptions.Seq;

                hostBuilder.UseSerilog((context, logger) =>
                {
                    logger
                        .Enrich.FromLogContext()
                        .Enrich.WithProperty("ServiceName", mainService.ServiceName)
                        .WriteTo.Seq(seqServiceConfig.ServiceUrl);
                });
            }

            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton(configuration);
            });

            return hostBuilder;
        }
    }
}
