using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleStore.Infrastructure.Common;
using SimpleStore.ProductCatalog.Infrastructure.EfCore;
using SimpleStore.ProductCatalogApi.GraphQL.ObjectTypes;
using SimpleStore.ProductCatalogApi.Options;
using System.Threading.Tasks;

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
                .AddSingleton(this.Configuration);

            services
                .AddEfCore()
                .AddCustomMediatR()
                .AddCustomValidators()
                .AddCustomHostedServices();

            services
                .AddGraphQL(sp => Schema.Create(cfg =>
                {
                    cfg.RegisterServiceProvider(sp);
                    cfg.RegisterQueryType<QueryType>();
                    cfg.RegisterMutationType<MutationType>();
                }), new QueryExecutionOptions
                {
                    IncludeExceptionDetails = true,
                    TracingPreference = TracingPreference.Always
                });
        }

        

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Listen(this._serviceOptions.ProductCatalogApi);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //In order to run our server we now just have to add the middleware.
            app.UseGraphQL("/graphql");

            //In order to write queries and execute them it would be practical if our server also serves up Playground
            app.UsePlayground(new PlaygroundOptions
            {
                QueryPath = "/graphql",
                Path = "/playground",
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", context =>
                {
                    context.Response.Redirect("/playground");
                    return Task.CompletedTask;
                });
            });
        }
    }
}
