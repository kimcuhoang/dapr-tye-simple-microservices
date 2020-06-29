using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SimpleStore.Infrastructure.Common.Extensions
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder AddCustomAppConfiguration(this IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.ConfigureAppConfiguration((webHostBuilderContext, configurationBuilder) =>
            {
                configurationBuilder
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{webHostBuilderContext.HostingEnvironment.EnvironmentName}.json", optional: true)
                    .AddJsonFile("services.json", optional: true)
                    .AddEnvironmentVariables();

                if (!webHostBuilderContext.HostingEnvironment.IsDevelopment()) return;

                var contentRootPath = webHostBuilderContext.HostingEnvironment.ContentRootPath;
                var servicesJson =
                    System.IO.Path.Combine(contentRootPath, "..", "..", "..", "..", "services.json");
                configurationBuilder.AddJsonFile(servicesJson, optional: true);
            });
            return webHostBuilder;
        }
    }
}
