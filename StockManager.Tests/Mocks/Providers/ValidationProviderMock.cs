using System.ComponentModel.DataAnnotations;
using StockManager.Domain.Contracts.Providers;

namespace StockManager.Tests.Mocks.Providers;

public sealed class ValidationProviderMock : ValidationProvider
{
    public ValidationContext? _validationContext;
    public List<ValidationResult>? _validationResults;

    public bool Validate<TPayload>(TPayload payload)
    {
        _validationContext = new ValidationContext(payload!, serviceProvider: null, items: null);
        _validationResults = new List<ValidationResult>();

        return Validator.TryValidateObject(
            payload!,
            _validationContext,
            _validationResults,
            validateAllProperties: true
        );
    }
}