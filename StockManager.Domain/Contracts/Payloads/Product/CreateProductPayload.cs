using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace StockManager.Domain.Contracts.Payloads.Product;

public record CreateProductPayload
(
    string Name,
    string Description,
    double Price
) : IPayload
{
    public void Validate()
    {
        var validator = new CreateProductPayloadValidator();
        validator.ValidateAndThrow(this);
    }

    public async Task ValidateAsync()
    {
        var validator = new CreateProductPayloadValidator();
        await validator.ValidateAndThrowAsync(this);
    }
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