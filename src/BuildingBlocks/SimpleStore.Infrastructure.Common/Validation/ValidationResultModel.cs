using FluentValidation.Results;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;

namespace SimpleStore.Infrastructure.Common.Validation
{
    public class ValidationResultModel
    {
        public int StatusCode => (int) HttpStatusCode.BadRequest;

        public IEnumerable<string> ValidationErrors { get; }

        public ValidationResultModel(IEnumerable<string> validationErrors)
            => this.ValidationErrors = validationErrors;

        #region Overrides of Object

        public override string ToString() => JsonSerializer.Serialize(this);

        #endregion
    }
}
