using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using SimpleStore.Infrastructure.Common.Tye;

namespace SimpleStore.Infrastructure.Common.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCustomApplicationBuilder(this IApplicationBuilder app)
        {
            var configuration =  app.ApplicationServices.GetRequiredService<IConfiguration>();

            var environment = app.ApplicationServices.GetRequiredService<IHostEnvironment>();

            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (!configuration.IsTyeEnabled())
            {
                app.UseSerilogRequestLogging();
            }

            app.UseRouting();

            return app;
        }
    }
}
