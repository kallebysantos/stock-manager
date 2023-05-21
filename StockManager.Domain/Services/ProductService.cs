using StockManager.Domain.Contracts.Payloads.Product;
using StockManager.Domain.Contracts.Providers;
using StockManager.Domain.Contracts.Repositories;
using StockManager.Domain.Models;

namespace StockManager.Domain.Services;

public record ProductService(
    IdProvider IdProvider,
    ValidationProvider Validator,
    UnitOfWorkProvider UnitOfWork,
    ProductRepository ProductRepository,
    SupplierRepository SupplierRepository
)
{
    public async Task<Product> CreateProduct(CreateProductPayload payload, string[] supplierIds)
    {
        await Validator.ValidateAsync(payload);

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
        catch (Exception)
        {
            await UnitOfWork.Rollback();
            throw;
        }
    }
}