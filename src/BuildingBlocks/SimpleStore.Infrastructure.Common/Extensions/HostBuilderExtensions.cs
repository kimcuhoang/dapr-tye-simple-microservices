using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using SimpleStore.Infrastructure.Common.Options;
using SimpleStore.Infrastructure.Common.Tye;
using System;
using System.Net;

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
                        var hostEnvironment = webHostBuilderContext.HostingEnvironment;

                        if (!configuration.EnabledTye())
                        {
                            var serviceConfig = getServiceConfigFn.Invoke(configuration);
                            var uri = new Uri(serviceConfig.ServiceUrl);
                            kestrelOptions.ListenAnyIP(uri.Port, options =>
                            {
                                options.UseConnectionLogging();
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
                        .Enrich.FromLogContext()
                        .Enrich.WithProperty("ServiceName", serviceConfig.ServiceName)
                        .WriteTo.Console()
                        .ReadFrom.Configuration(context.Configuration);
                });
            
    }
}
