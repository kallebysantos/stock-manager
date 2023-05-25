using FluentValidation;

namespace StockManager.Domain.Contracts.Payloads.Product;

public record CreateProductPayload
(
    string Name,
    string Description,
    double Price
) : IPayload
{
    private CreateProductPayloadValidator _validator = new();
    
    public Result Validate()
        => _validator.Validate(this).ToFluentResult();

    public async Task<Result> ValidateAsync()
        => (await _validator.ValidateAsync(this)).ToFluentResult();
}

public class CreateProductPayloadValidator : AbstractValidator<CreateProductPayload>
{
    public CreateProductPayloadValidator()
    {
        RuleFor(input => input.Name)
            .NotEmpty()
            .NotNull();

        RuleFor(input => input.Description)
            .MinimumLength(5)
            .NotEmpty()
            .NotNull();

        RuleFor(input => input.Price)
            .GreaterThan(0)
            .NotEmpty()
            .NotNull();
    }
}