namespace StockManager.Domain.Contracts.Providers;

/// <summary>
/// Represents an ID provider that generates valid and unique IDs.
/// </summary>
public interface IdProvider
{
    /// <summary>
    /// Generates a valid and unique ID asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the generated ID as a string.</returns>
    Task<string> GenerateId();

    /// <summary>
    /// Invalidates an ID, making it no longer valid or unique.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task InvalidateId();
}
