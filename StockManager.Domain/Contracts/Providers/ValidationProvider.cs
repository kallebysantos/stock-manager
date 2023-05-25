// using StockManager.Domain.Contracts.Payloads;

// namespace StockManager.Domain.Contracts.Providers;

// public interface ValidationProvider
// {
//     Result<TPayload> Validate<TPayload>(TPayload payload) where TPayload : IPayload;

//     Task<Result<TPayload>> ValidateAsync<TPayload>(TPayload payload) where TPayload : IPayload;
// }

// public record DefaultValidationProvider() : ValidationProvider
// {
//     public Result<TPayload> Validate<TPayload>(TPayload payload) where TPayload : IPayload
//     {
//         try
//         {
//             payload.Validate();

//             return Result.Ok(payload);
//         }
//         catch (System.Exception ex)
//         {
//             return Result.Fail(new Error("Payload validation error").CausedBy(ex));
//         }
//     }

//     public async Task<Result<TPayload>> ValidateAsync<TPayload>(TPayload payload) where TPayload : IPayload
//     {
//         try
//         {
//             await payload.ValidateAsync();

//             return Result.FromValue<TPayload>(payload);
//         }
//         catch (System.Exception e)
//         {
//             return  Result.FromException<TPayload>(e);
//         }   
//     }
// }