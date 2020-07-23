using HotChocolate;
using HotChocolate.AspNetCore.Subscriptions;
using HotChocolate.Stitching;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleStore.GraphQLApi.Options;
using SimpleStore.Infrastructure.Common.Extensions;
using SimpleStore.Infrastructure.Common.GraphQL;
using SimpleStore.Infrastructure.Common.Options;
using SimpleStore.Infrastructure.Common.Tye;
using System;
using Microsoft.Extensions.Options;
using SimpleStore.Infrastructure.Common.HealthCheck;

namespace SimpleStore.GraphQLApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddHealthChecks();

            // C# 8.0, this is local function

            Uri GetGraphQLUriFor(IServiceProvider serviceProvider, Func<ServiceOptions, ServiceConfig> getServiceConfigFn)
            {
                var serviceOptions = serviceProvider.GetRequiredService<IOptions<ServiceOptions>>().Value;
                var serviceConfig = getServiceConfigFn.Invoke(serviceOptions);

                var graphqlUri = new Uri("graphql", UriKind.Relative);
                var serviceUri = this.Configuration.GetServiceUriFor(serviceConfig);

                return new Uri(serviceUri, graphqlUri);
            }
            // End of local function

            services.AddHttpClient(nameof(ServiceOptions.ProductCatalogApi), (sp, client) =>
            {
                client.BaseAddress = GetGraphQLUriFor(sp, serviceOptions => serviceOptions.ProductCatalogApi);
            }); 
            services.AddHttpClient(nameof(ServiceOptions.InventoriesApi), (sp, client) =>
            {
                client.BaseAddress = GetGraphQLUriFor(sp, serviceOptions => serviceOptions.InventoriesApi);
            });

            services
                .AddGraphQLSubscriptions()
                .AddStitchedSchema(stitchingBuilder =>
                    stitchingBuilder
                        .AddSchemaFromHttp(nameof(ServiceOptions.ProductCatalogApi))
                        .AddSchemaFromHttp(nameof(ServiceOptions.InventoriesApi)));
        }

        public void Configure(IApplicationBuilder app)
            => app
                .UseCustomApplicationBuilder()
                .UseCustomGraphQL(endpoints =>
                {
                    endpoints.UseCustomMapHealthCheck();
                });
    }
}
