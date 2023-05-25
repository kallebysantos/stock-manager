namespace StockManager.Domain.Contracts.Payloads;


public interface IPayload
{
    Result Validate();
    Task<Result> ValidateAsync();
}