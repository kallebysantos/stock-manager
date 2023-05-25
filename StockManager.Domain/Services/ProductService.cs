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
        if(result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }

        var product = new Product(
            Id: await IdProvider.GenerateId(),
            Name: payload.Name,
            Description: payload.Description,
            Price: payload.Price
        );

        try
        {
            await UnitOfWork.Begin();

            foreach (var supplier in await SupplierRepository.GetSuppliersByIds(supplierIds, lazy: true))
            {
                product.AssociateSupplier(supplier);
            }

            await ProductRepository.PersistProduct(product);
            
            await UnitOfWork.Commit();

            return product;
        }
        catch (Exception err)
        {
            await UnitOfWork.Rollback();
            
            return new Error(err.Message).CausedBy(err);
        }
    }
}