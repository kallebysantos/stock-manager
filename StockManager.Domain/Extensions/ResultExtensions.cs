namespace StockManager.Domain.Extentions;

public static class ResultExtensions
{
    public static Result ToFluentResult(this FluentValidation.Results.ValidationResult result) 
        => result.Errors.Select(err  => new Error(err.ErrorMessage)
            .WithMetadata(nameof(err.AttemptedValue), err.AttemptedValue)
            .WithMetadata(nameof(err.CustomState), err.CustomState)
            .WithMetadata(nameof(err.ErrorCode), err.ErrorCode)
            .WithMetadata(nameof(err.PropertyName), err.PropertyName)
            .WithMetadata(nameof(err.Severity), err.Severity)
        ).ToList();
}