using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleStore.Infrastructure.Common.Extensions;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Options;
using System.Diagnostics;
using System.IO;
using ConfigurationExtensions = SimpleStore.Infrastructure.Common.Extensions.ConfigurationExtensions;

namespace SimpleStore.ProductCatalogApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var serviceOptions = new ServiceOptions();
            var configuration = ConfigurationExtensions.BuildConfiguration(Directory.GetCurrentDirectory());

            var serviceOptionsSection = configuration.GetSection("Services");
            serviceOptionsSection.Bind(serviceOptions);

            return Host
                .CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddOptions<ServiceOptions>().Bind(serviceOptionsSection);
                })
                .CustomConfigWebHostFor(serviceOptions.ProductCatalogApi, typeof(Startup), configuration, serviceOptions);
        }
    }
}
