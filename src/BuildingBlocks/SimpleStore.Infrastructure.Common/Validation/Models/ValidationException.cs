using System;

namespace SimpleStore.Infrastructure.Common.Validation.Models
{
    public class ValidationException : Exception
    {
        public ValidationException(ValidationResultModel validationResultModel)
        {
            ValidationResultModel = validationResultModel;
        }

        public ValidationResultModel ValidationResultModel { get; }
    }
}
