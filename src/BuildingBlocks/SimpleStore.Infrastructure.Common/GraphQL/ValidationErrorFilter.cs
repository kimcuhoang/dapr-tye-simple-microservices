using System.Linq;
using FluentValidation;
using HotChocolate;
using SimpleStore.Infrastructure.Common.Validation;

namespace SimpleStore.Infrastructure.Common.GraphQL
{
    public class ValidationErrorFilter : IErrorFilter
    {
        #region Implementation of IErrorFilter

        public IError OnError(IError error)
        {
            if (!(error.Exception is ValidationException exception)) return error;

            var validationResult = new ValidationResultModel(exception.Errors.Select(x => x.ErrorMessage));

            return error.AddExtension("ValidationError", validationResult);

        }

        #endregion
    }
}
