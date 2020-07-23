using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleStore.Infrastructure.Common.Extensions;
using SimpleStore.Infrastructure.Common.GraphQL;
using SimpleStore.Infrastructure.Common.HealthCheck;
using SimpleStore.Inventories.Infrastructure.EfCore;
using SimpleStore.InventoriesApi.GraphQL.Objects;

namespace SimpleStore.InventoriesApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var healthCheckBuilder = services.AddHealthChecks();

            services
                .AddCustomInfrastructure(this.Configuration, healthCheckBuilder)
                .AddCustomGraphQL(cfg =>
                {
                    cfg.RegisterQueryType<QueryInventories>();
                    cfg.RegisterMutationType<InventoryMutation>();
                });
        }


        public void Configure(IApplicationBuilder app)
            => app
                .UseCustomApplicationBuilder()
                .UseCloudEvents()
                .UseCustomGraphQL(endpoints =>
                {
                    endpoints.MapSubscribeHandler();
                    endpoints.MapControllers();
                    endpoints.UseCustomMapHealthCheck();
                });
    }
}
