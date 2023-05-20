using StockManager.Domain.Models;

namespace StockManager.Domain.Contracts.Repositories;

public interface ProductRepository
{
    Task<IEnumerable<Product>> GetProducts();

    Task<Product> FindProductById(Guid productId);

    Task PersistProduct(Product product);

    Task RemoveProductById(Guid productId);
}