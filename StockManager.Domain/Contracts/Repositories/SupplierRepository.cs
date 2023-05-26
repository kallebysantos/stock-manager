using StockManager.Domain.Models;

namespace StockManager.Domain.Contracts.Repositories;

/// <summary>
/// Represents a repository for managing Suppliers.
/// </summary>
public interface SupplierRepository
{
    /// <summary>
    /// Retrieves all Suppliers.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of Suppliers.</returns>
    Task<IEnumerable<Supplier>> GetSuppliers();

    /// <summary>
    /// Retrieves all Suppliers based on their IDs.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of Suppliers.</returns>
    Task<Result<IEnumerable<Supplier>>> GetSuppliersByIds(string[] supplierIds, bool lazy = false);

    /// <summary>
    /// Finds a Supplier by its unique identifier.
    /// </summary>
    /// <param name="SupplierId">The unique identifier of the Supplier to find.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the found Supplier, or null if not found.</returns>
    Task<Supplier?> FindSupplierById(string SupplierId);

    /// <summary>
    /// Persists a Supplier.
    /// </summary>
    /// <param name="Supplier">The Supplier to persist.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task PersistSupplier(Supplier Supplier);

    /// <summary>
    /// Removes a Supplier by its unique identifier.
    /// </summary>
    /// <param name="SupplierId">The unique identifier of the Supplier to remove.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task RemoveSupplierById(string SupplierId);
}
