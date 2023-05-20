
using StockManager.Domain.Contracts.Payloads.Product;
using StockManager.Domain.Services;

namespace StockManager.Tests.Services;

public class ProductServiceTests
{
    [Fact]
    public async Task Create_Product()
    {
        #region Setup

        var _productsMock = new ProductRepositoryMock();
        await _productsMock.PopulateFromJson("10_ProductsMock");

        var _suppliersMock = new SupplierRepositoryMock();
        await _suppliersMock.PopulateFromJson("10_SuppliersMock");

        var _service = new ProductService(
            ProductRepository: _productsMock,
            SupplierRepository: _suppliersMock,
            IdProvider: new IdProviderMock(),
            Validator: new ValidationProviderMock(),
            UnitOfWork: new UnitOfWorkProviderMock()
        );
        #endregion

        var payload = new CreateProductPayload(
            Name: "Home Improvement Apparatus",
            Price: 188.95,
            Description: "Integer ut tellus leo. Aenean vehicula sem ut tortor."
        );

        var suppliersIds = _suppliersMock.Entities!
            .Select(s => s.Id)
            .Take(3)
            .ToArray();

        var product = await _service.CreateProduct(payload, suppliersIds);

        var suppliers = _suppliersMock.Entities!.Where(s => suppliersIds.Contains(s.Id));
        var productInMock = _productsMock.Entities!.FirstOrDefault(p => p.Id == product.Id);

        Assert.NotNull(product);
        Assert.NotNull(productInMock);

        Assert.Equal(productInMock, product);

        foreach (var supplier in suppliers)
        {
            Assert.Contains(supplier, product.Suppliers);
            Assert.Contains(product, supplier.Products);
        }

        Assert.Equal(11, _productsMock.Entities!.Count);
        Assert.Equal(3, product.Suppliers.Count);
    }
}