using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using SimpleStore.Infrastructure.Common.Options;
using System;
using SimpleStore.Infrastructure.Common.Tye;

namespace SimpleStore.Infrastructure.Common.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder CustomConfigure(this IHostBuilder hostBuilder, Type startupType, Func<IConfiguration, ServiceConfig> getServiceConfigFn)
        => hostBuilder
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup(startupType);
                    webBuilder.ConfigureAppConfiguration((webHostBuilderContext, configurationBuilder) =>
                    {
                        configurationBuilder
                            .AddJsonFile("appsettings.json")
                            .AddJsonFile($"appsettings.{webHostBuilderContext.HostingEnvironment.EnvironmentName}.json", optional: true)
                            .AddJsonFile("services.json", optional: true)
                            .AddEnvironmentVariables();

                        if (!webHostBuilderContext.HostingEnvironment.IsDevelopment()) return;

                        var contentRootPath = webHostBuilderContext.HostingEnvironment.ContentRootPath;
                        var servicesJson = System.IO.Path.Combine(contentRootPath, "..", "..", "..", "..", "services.json");
                        configurationBuilder.AddJsonFile(servicesJson, optional: true);
                    });
                    webBuilder.CaptureStartupErrors(true);
                    webBuilder.ConfigureKestrel((webHostBuilderContext, kestrelOptions) =>
                    {
                        var configuration = webHostBuilderContext.Configuration;
                        if (!configuration.EnabledTye())
                        {
                            var serviceConfig = getServiceConfigFn.Invoke(configuration);
                            var serviceUri = configuration.GetServiceUri(serviceConfig.ServiceName);

                            kestrelOptions.ListenAnyIP(serviceUri.Port, listenOptions =>
                            {
                                listenOptions.UseConnectionLogging();
                            });
                        }
                    });
                })
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                    options.ValidateOnBuild = true;
                })
                .UseSerilog((context, loggerConfiguration) =>
                {
                    var serviceConfig = getServiceConfigFn.Invoke(context.Configuration);

                    loggerConfiguration
                        .WriteTo.Console()
                        .Enrich.FromLogContext()
                        .Enrich.WithProperty("Service", serviceConfig.ServiceName)
                        .ReadFrom.Configuration(context.Configuration);
                });
            
    }
}
