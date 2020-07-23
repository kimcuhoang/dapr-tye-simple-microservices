using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleStore.Infrastructure.Common.Validation
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ILogger<RequestValidationBehavior<TRequest, TResponse>> _logger;


        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<RequestValidationBehavior<TRequest, TResponse>> logger)
        {
            this._validators = validators;
            this._logger = logger;
        }

        #region Implementation of IPipelineBehavior<in TRequest,TResponse>

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            this._logger.LogInformation($"Start validation for {nameof(request)}");

            if (this._validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults =
                    await Task.WhenAll(this._validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                var failures = validationResults.SelectMany(x => x.Errors).Where(f => f != null).ToList();

                if (failures.Any())
                {
                    throw new ValidationException(failures);
                }

            }

            this._logger.LogInformation($"The {nameof(request)} is valid.");

            return await next();
        }

        #endregion
    }
}