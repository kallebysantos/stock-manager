using StockManager.Domain.Contracts.Payloads;

namespace StockManager.Domain.Contracts.Providers;

public interface ValidationProvider
{
    void Validate<TPayload>(TPayload payload) where TPayload : IPayload;

    Task ValidateAsync<TPayload>(TPayload payload) where TPayload : IPayload;
}

public record DefaultValidationProvider() : ValidationProvider
{
    public void Validate<TPayload>(TPayload payload) where TPayload : IPayload
    {
        payload.Validate();
    }

    public async Task ValidateAsync<TPayload>(TPayload payload) where TPayload : IPayload
    {
        await payload.ValidateAsync();
    }
}