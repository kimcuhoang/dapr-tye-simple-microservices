using System;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace SimpleStore.Infrastructure.Common.GraphQL
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCustomGraphQL(this IApplicationBuilder app, Action<IEndpointRouteBuilder> extendEndpointRouteBuilder = null)
        {
            app.UseRouting();

            //In order to run our server we now just have to add the middleware.
            app.UseGraphQL("/graphql");

            //In order to write queries and execute them it would be practical if our server also serves up Playground
            app.UsePlayground(new PlaygroundOptions
            {
                QueryPath = "/graphql",
                Path = "/playground",
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", context =>
                {
                    context.Response.Redirect("/playground");
                    return Task.CompletedTask;
                });

                extendEndpointRouteBuilder?.Invoke(endpoints);

            });

            return app;
        }
    }
}
