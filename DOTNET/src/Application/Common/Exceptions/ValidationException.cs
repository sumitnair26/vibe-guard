using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ModelStateDictionary Errors { get; } = new();

    public ValidationException(IEnumerable<ValidationFailure> failures) : base("One or more validation errors occurred.")
    {
        foreach (ValidationFailure failure in failures)
        {
            Errors.AddModelError(failure.PropertyName, failure.ErrorMessage);
        }
    }
}
