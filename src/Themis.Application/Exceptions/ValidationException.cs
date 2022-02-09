using FluentValidation.Results;

namespace Themis.Application
{
    public class ValidationException : Exception
    {
        public ValidationException(ValidationResult validationResult, string name)
            : base($"{name} is invalid. {validationResult}")
        {
            ValidationResult = validationResult;
        }

        public ValidationResult ValidationResult { get; }
    }
}
