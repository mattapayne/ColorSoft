using System;
using System.Collections.Generic;

namespace ColorSoft.Web.Validation
{
    public class ApplicationValidationException : Exception
    {
        private readonly IList<ValidationError> _errors;
        public IEnumerable<ValidationError> Errors { get { return _errors; } }

        public ApplicationValidationException()
        {
            _errors = new List<ValidationError>();
        }

        public void AddError(string propertyName, string errorMessage)
        {
            _errors.Add(new ValidationError {ErrorMessage = errorMessage, PropertyName = propertyName});
        }
    }
}