using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleStore.Infrastructure.Common.Extensions;
using SimpleStore.Infrastructure.Common.GraphQL;
using SimpleStore.Infrastructure.Common.HealthCheck;
using SimpleStore.ProductCatalog.Infrastructure.EfCore;
using SimpleStore.ProductCatalogApi.GraphQL.ObjectTypes;

namespace SimpleStore.ProductCatalogApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var healthCheckBuilder = services.AddHealthChecks();

            services
                .AddCustomInfrastructure(this.Configuration, healthCheckBuilder)
                .AddCustomGraphQL(cfg =>
                {
                    cfg.RegisterQueryType<QueryType>();
                    cfg.RegisterMutationType<MutationType>();
                });
        }

        public void Configure(IApplicationBuilder app)
            => app
                .UseCustomApplicationBuilder()
                .UseCustomGraphQL(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.UseCustomMapHealthCheck();
                });
    }
}
