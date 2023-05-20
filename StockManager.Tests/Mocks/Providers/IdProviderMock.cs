using StockManager.Domain.Contracts.Providers;

namespace StockManager.Tests.Mocks.Providers;

public sealed class IdProviderMock : IdProvider
{
    public Task<string> GenerateId() => Task.FromResult(Guid.NewGuid().ToString());

    public Task InvalidateId() => Task.CompletedTask;
}