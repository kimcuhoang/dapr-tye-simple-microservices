using HotChocolate;
using HotChocolate.Configuration;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SimpleStore.Infrastructure.Common.GraphQL
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddCustomGraphQL(this IServiceCollection services, Action<ISchemaConfiguration> schemaConfiguration = null)
        {
            services
                .AddGraphQL(sp => Schema.Create(cfg =>
                {
                    cfg.RegisterServiceProvider(sp);
                    schemaConfiguration?.Invoke(cfg);
                }), new QueryExecutionOptions
                {
                    IncludeExceptionDetails = true,
                    TracingPreference = TracingPreference.Always
                });

            return services;
        }
    }
}
