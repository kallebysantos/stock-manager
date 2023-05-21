namespace StockManager.Domain.Contracts.Payloads;

public interface IPayload
{
    void Validate();
    Task ValidateAsync();
}