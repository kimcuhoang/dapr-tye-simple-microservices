using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SimpleStore.Domain.Models;
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

        public static IServiceCollection AddDomainEventDispatcher(this IServiceCollection services)
        {
            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
            return services;
        }
    }
}
