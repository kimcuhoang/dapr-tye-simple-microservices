using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Trace.Configuration;
using OpenTelemetry.Trace.Samplers;
using SimpleStore.Infrastructure.Common.Extensions;
using SimpleStore.Infrastructure.Common.Options;
using System;

namespace SimpleStore.Infrastructure.Common.Tracing
{
    public static class OpenTelemetryRegistration
    {
        public static IServiceCollection AddCustomOpenTelemetry(this IServiceCollection services, IConfiguration configuration, ServiceConfig serviceConfig)
        {
            var zipkinConfig = configuration.GetOptions<ZipkinOption>("Zipkin");

            if (!zipkinConfig.Enabled) return services;

            services
                .AddHttpClient()
                .AddOpenTelemetry(builder =>
                {
                    builder
                        .UseZipkin(options =>
                        {
                            options.ServiceName = serviceConfig.ServiceName;
                            options.Endpoint = new Uri(zipkinConfig.EndpointUrl);
                        })
                        .SetSampler(new ProbabilitySampler(0.1))
                        .AddRequestInstrumentation()
                        .AddDependencyInstrumentation();

                });

            return services;
        }
    }
}
