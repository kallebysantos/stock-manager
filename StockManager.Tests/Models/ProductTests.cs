using StockManager.Domain.Models;

namespace StockManager.Tests.Models;

[TestClass]
public class ProductTests
{
    [TestMethod]
    [DataRow(10, 5, 9.5)]
    [DataRow(30, 50, 15)]
    [DataRow(5, 25, 3.75)]
    public void Apply_Discount(double initialPrice, double discount, double finalPrice)
    {
        var product = new Product(
            Id: Guid.NewGuid().ToString(),
            Name: "Test Product",
            Description: "Some test product.",
            Price: initialPrice,
            Suppliers: new HashSet<Supplier>()
        );

        Assert.AreEqual(
            expected: finalPrice,
            actual: product.ApplyDiscount(discount).Price
        );
    }
}