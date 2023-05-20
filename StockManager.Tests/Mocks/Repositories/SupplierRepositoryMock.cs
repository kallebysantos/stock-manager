using System.Text.Json;
using StockManager.Domain.Contracts.Repositories;
using StockManager.Domain.Models;

namespace StockManager.Tests.Mocks.Repositories;

public sealed record SupplierRepositoryMock() : BaseMockRepository<Supplier>, SupplierRepository
{
    public SupplierRepositoryMock(string jsonMock) : this()
    {
        var jsonFile = File.OpenRead(Path.Combine("../Data", jsonMock, ".json"));

        JsonSerializer.Deserialize<HashSet<Product>>(jsonFile);
    }

    public Task<Supplier?> FindSupplierById(string SupplierId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Supplier>> GetSuppliers()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Supplier>> GetSuppliersByIds(string[] supplierIds, bool lazy = false)
        => Task.FromResult(Entities!.Where(s => supplierIds.Contains(s.Id)));


    public Task PersistSupplier(Supplier Supplier)
    {
        Entities!.Add(Supplier);

        return Task.CompletedTask;
    }

    public Task RemoveSupplierById(string SupplierId)
    {
        throw new NotImplementedException();
    }
}