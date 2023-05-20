namespace StockManager.Domain.Contracts.Providers;

public interface UnitOfWorkProvider : IAsyncDisposable
{
    Task Begin();

    Task Commit();

    Task Rollback();
}