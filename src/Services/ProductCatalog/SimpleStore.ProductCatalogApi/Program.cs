using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace SimpleStore.ProductCatalogApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
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
                    //options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                    options.ValidateOnBuild = true;
                })
                .UseSerilog();
    }
}
