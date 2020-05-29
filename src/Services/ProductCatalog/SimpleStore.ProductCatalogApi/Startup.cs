using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SimpleStore.Infrastructure.Common.Extensions;
using SimpleStore.Infrastructure.Common.GraphQL;
using SimpleStore.ProductCatalog.Infrastructure.EfCore;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Options;
using SimpleStore.ProductCatalogApi.GraphQL.ObjectTypes;

namespace SimpleStore.ProductCatalogApi
{
    public class Startup
    {
        private readonly ServiceOptions _serviceOptions;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            this._serviceOptions = this.Configuration.GetOptions<ServiceOptions>("Services");
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton(this.Configuration)
                .AddCustomInfrastructure(this.Configuration)
                .AddCustomGraphQL(cfg =>
                {
                    cfg.RegisterQueryType<QueryType>();
                    cfg.RegisterMutationType<MutationType>();
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptionsMonitor<ServiceOptions> optionsAccessor)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.Listen(this.Configuration, this._serviceOptions.ProductCatalogApi);
            }
            app.UseCustomGraphQL();
        }
    }
}
