using StockManager.Domain.Contracts.Payloads.Product;
using StockManager.Domain.Contracts.Providers;
using StockManager.Domain.Contracts.Repositories;
using StockManager.Domain.Models;

namespace StockManager.Domain.Services;

public record ProductService(
    IdProvider IdProvider,
    UnitOfWorkProvider UnitOfWork,
    ProductRepository ProductRepository,
    SupplierRepository SupplierRepository
)
{
    public async Task<Result<Product>> CreateProduct(CreateProductPayload payload, string[] supplierIds)
    {
        var result = await payload.ValidateAsync();
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }

        var product = new Product(
            Id: await IdProvider.GenerateId(),
            Name: payload.Name,
            Description: payload.Description,
            Price: payload.Price
        );

        await UnitOfWork.Begin();

        var suppliers = await SupplierRepository.GetSuppliersByIds(supplierIds, lazy: true);
        if (suppliers.IsFailed)
        {
            return Result.Fail(suppliers.Errors);
        }

        foreach (var supplier in suppliers.Value)
        {
            product.AssociateSupplier(supplier);
        }

        var hasPersisted = await ProductRepository.PersistProduct(product);
        if (hasPersisted.IsFailed)
        {
            return Result.Fail(hasPersisted.Errors);
        }

        var hasCommited = await UnitOfWork.Commit();
        if (hasCommited.IsFailed)
        {
            await UnitOfWork.Rollback();
            return Result.Fail(hasCommited.Errors);
        }

        return product;
    }
}
