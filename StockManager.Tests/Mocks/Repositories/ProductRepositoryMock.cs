using StockManager.Domain.Contracts.Repositories;
using StockManager.Domain.Models;

namespace StockManager.Tests.Mocks.Repositories;

public sealed class ProductRepositoryMock : ProductRepository
{
    public HashSet<Product> Products { get; set; } = new();

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
        Products.Add(product);

        return Task.CompletedTask;
    }

    public Task RemoveProductById(string productId)
    {
        throw new NotImplementedException();
    }
}