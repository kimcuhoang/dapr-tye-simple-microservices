using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleStore.Infrastructure.Common.Extensions;
using SimpleStore.Infrastructure.Common.GraphQL;
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

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services
                .AddCustomInfrastructure(this.Configuration)
                .AddCustomGraphQL(cfg =>
                {
                    cfg.RegisterQueryType<QueryType>();
                    cfg.RegisterMutationType<MutationType>();
                });
        }

        public void Configure(IApplicationBuilder app)
            => app.UseCustomApplicationBuilder().UseCustomGraphQL(endpoints =>
                {
                    endpoints.MapControllers();
                });
    }
}
