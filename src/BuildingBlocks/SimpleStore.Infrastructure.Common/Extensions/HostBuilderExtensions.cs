using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using SimpleStore.Infrastructure.Common.Options;

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
