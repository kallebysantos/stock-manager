namespace StockManager.Domain.Contracts.Providers;

public interface ValidationProvider
{
    bool Validate<TPayload>(TPayload payload);
}