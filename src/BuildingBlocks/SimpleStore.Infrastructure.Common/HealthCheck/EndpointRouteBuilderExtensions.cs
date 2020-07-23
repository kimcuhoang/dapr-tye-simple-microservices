using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Routing;

namespace SimpleStore.Infrastructure.Common.HealthCheck
{
    public static class EndpointRouteBuilderExtensions
    {
        public static IEndpointRouteBuilder UseCustomMapHealthCheck(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapHealthChecks("/ready", new HealthCheckOptions
            {
                Predicate = reg => reg.Tags.Contains("readiness")
            });
            endpoints.MapHealthChecks("/lively", new HealthCheckOptions
            {
                Predicate = reg => reg.Tags.Contains("liveness")
            });
            return endpoints;
        }
    }
}