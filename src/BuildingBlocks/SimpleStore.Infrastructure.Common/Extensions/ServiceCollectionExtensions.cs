using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SimpleStore.Infrastructure.Common.Validation;

namespace SimpleStore.Infrastructure.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomRequestValidation(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            return services;
        }
    }
}
