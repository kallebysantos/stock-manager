using System.Text.Json;
using StockManager.Domain.Contracts.Repositories;
using StockManager.Domain.Models;

namespace StockManager.Tests.Mocks.Repositories;

public sealed record ProductRepositoryMock() : BaseMockRepository<Product>, ProductRepository
{
    public Task<Product?> FindProductById(string productId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetProducts()
    {
        throw new NotImplementedException();
    }

    public Task PersistProduct(Product product)
    {
        Entities!.Add(product);

        return Task.CompletedTask;
    }

    public Task RemoveProductById(string productId)
    {
        throw new NotImplementedException();
    }
}