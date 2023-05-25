
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

        var result = await _service.CreateProduct(payload, suppliersIds);
        result.Should().BeSuccess();
        result.Should().NotBeNull();

        var product = result.Value;

        var productInMock = _productsMock.Entities!.FirstOrDefault(p => p.Id == product.Id);
        Assert.NotNull(productInMock);
        Assert.Equal(productInMock, product);

        var suppliers = _suppliersMock.Entities!.Where(s => suppliersIds.Contains(s.Id));

        foreach (var supplier in suppliers)
        {
            Assert.Contains(supplier, product.Suppliers);
            Assert.Contains(product, supplier.Products);
        }

        Assert.Equal(11, _productsMock.Entities!.Count);
        Assert.Equal(3, product.Suppliers.Count);
    }

    [Theory]
    [InlineData(null!, null!, 0)]
    [InlineData("", "12345", -1)]
    [InlineData("Test", "123", 1)]
    public async Task Create_Product_Invalid_data(string? Name, string? Description, double Price)
    {
        #region Setup

        var _productsMock = new ProductRepositoryMock();

        var _service = new ProductService(
            ProductRepository: _productsMock,
            SupplierRepository: new SupplierRepositoryMock(),
            IdProvider: new IdProviderMock(),
            UnitOfWork: new UnitOfWorkProviderMock()
        );
        #endregion

        var payload = new CreateProductPayload(Name!, Description!, Price);

        var result = await _service.CreateProduct(payload, new string[0]);
        result.Should().BeFailure();
    }

    [Fact]
    public async Task Create_Product_Invalid_Supplier()
    {
        var _productsMock = new ProductRepositoryMock();
        await _productsMock.PopulateFromJson("10_ProductsMock");

        var _suppliersMock = new SupplierRepositoryMock();
        await _suppliersMock.PopulateFromJson("10_SuppliersMock");

        var _service = new ProductService(
            ProductRepository: _productsMock,
            SupplierRepository: _suppliersMock,
            IdProvider: new IdProviderMock(),
            UnitOfWork: new UnitOfWorkProviderMock()
        );

        var payload = new CreateProductPayload(
            Name: "Home Improvement Apparatus",
            Price: 188.95,
            Description: "Integer ut tellus leo. Aenean vehicula sem ut tortor."
        );

        var suppliersIds = _suppliersMock.Entities!
            .Select(s => s.Id)
            .Take(2)
            .Append(Guid.NewGuid().ToString())
            .ToArray();

        var result = await _service.CreateProduct(payload, suppliersIds);
        result.Should().BeFailure();
        result.Should().BeNull();

    }
}
