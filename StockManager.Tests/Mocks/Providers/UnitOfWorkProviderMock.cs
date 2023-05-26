using StockManager.Domain.Contracts.Providers;

namespace StockManager.Tests.Mocks.Providers;

public sealed class UnitOfWorkProviderMock : UnitOfWorkProvider
{
    public Task<Result> Begin() => Task.FromResult(Result.Ok());

    public Task<Result> Commit() => Task.FromResult(Result.Ok());

    public Task<Result> Rollback() => Task.FromResult(Result.Ok());

    public async ValueTask DisposeAsync() => await Task.FromResult(0);
}
