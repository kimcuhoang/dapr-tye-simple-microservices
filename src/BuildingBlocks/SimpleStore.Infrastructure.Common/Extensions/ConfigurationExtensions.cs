using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SimpleStore.Infrastructure.Common.Extensions
{
    public static class ConfigurationExtensions
    {
        public static TModel GetOptions<TModel>(this IConfiguration configuration, string section) where TModel : new()
        {
            var model = new TModel();
            configuration.GetSection(section).Bind(model);
            return model;
        }

        public static IConfiguration BuildConfiguration(string contentRootPath)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environments.Development;

            var configurationBuilder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddJsonFile("services.json", optional: true);

            if (environment == Environments.Development)
            {
                var servicesJson = System.IO.Path.Combine(contentRootPath, "..", "..", "..", "..", "services.json");
                configurationBuilder.AddJsonFile(servicesJson, optional: true);
            }

            return configurationBuilder.Build();
        }
    }
}
