using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleStore.Infrastructure.Common.Extensions;
using SimpleStore.Infrastructure.Common.GraphQL;
using SimpleStore.Inventories.Infrastructure.EfCore;
using SimpleStore.InventoriesApi.GraphQL.Objects;

namespace SimpleStore.InventoriesApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services
                .AddCustomInfrastructure(this.Configuration)
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
                });
    }
}
