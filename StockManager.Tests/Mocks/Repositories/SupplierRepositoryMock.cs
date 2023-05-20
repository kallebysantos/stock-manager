using StockManager.Domain.Contracts.Repositories;
using StockManager.Domain.Models;

namespace StockManager.Tests.Mocks.Repositories;

public sealed class SupplierRepositoryMock : SupplierRepository
{
    public HashSet<Supplier> Suppliers { get; set; } = new();

    public Task<Supplier?> FindSupplierById(string SupplierId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Supplier>> GetSuppliers()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Supplier>> GetSuppliersByIds(string[] supplierIds, bool lazy = false)
        => Task.FromResult(Suppliers.Where(s => supplierIds.Contains(s.Id)));


    public Task PersistSupplier(Supplier Supplier)
    {
        Suppliers.Add(Supplier);

        return Task.CompletedTask;
    }

    public Task RemoveSupplierById(string SupplierId)
    {
        throw new NotImplementedException();
    }
}