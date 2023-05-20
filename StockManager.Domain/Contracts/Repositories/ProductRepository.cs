using StockManager.Domain.Models;

namespace StockManager.Domain.Contracts.Repositories;

/// <summary>
/// Represents a repository for managing products.
/// </summary>
public interface ProductRepository
{
    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of products.</returns>
    Task<IEnumerable<Product>> GetProducts();

    /// <summary>
    /// Finds a product by its unique identifier.
    /// </summary>
    /// <param name="productId">The unique identifier of the product to find.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the found product, or null if not found.</returns>
    Task<Product?> FindProductById(string productId);

    /// <summary>
    /// Persists a product.
    /// </summary>
    /// <param name="product">The product to persist.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task PersistProduct(Product product);

    /// <summary>
    /// Removes a product by its unique identifier.
    /// </summary>
    /// <param name="productId">The unique identifier of the product to remove.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task RemoveProductById(string productId);
}
