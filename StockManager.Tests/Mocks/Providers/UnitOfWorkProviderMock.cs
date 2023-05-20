using StockManager.Domain.Contracts.Providers;

namespace StockManager.Tests.Mocks.Providers;

public sealed class UnitOfWorkProviderMock : UnitOfWorkProvider
{
    public Task Begin() => Task.CompletedTask;

    public Task Commit() => Task.CompletedTask;

    public Task Rollback() => Task.CompletedTask;

    public async ValueTask DisposeAsync() => await Task.FromResult(0);
}