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

    public Task<Result<IEnumerable<Supplier>>> GetSuppliersByIds(string[] supplierIds, bool lazy = false)
    {

        var allSuppliersMatchs = Entities!.Count(s => supplierIds.Contains(s.Id)) == supplierIds.Count();

        var suppliers = Entities!.Where(s => supplierIds.Contains(s.Id));

        var result = Result.OkIf(allSuppliersMatchs, "Invalid SupplierId").ToResult(suppliers);

        return Task.FromResult(result);
    }

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
