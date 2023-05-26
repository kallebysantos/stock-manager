namespace StockManager.Domain.Contracts.Providers;

public interface UnitOfWorkProvider : IAsyncDisposable
{
    Task<Result> Begin();

    Task<Result> Commit();

    Task<Result> Rollback();
}
