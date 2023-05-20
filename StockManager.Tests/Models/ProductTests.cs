using StockManager.Domain.Models;

namespace StockManager.Tests.Models;

public class ProductTests
{
    [Theory]
    [InlineData(10, 5, 9.5)]
    [InlineData(30, 50, 15)]
    [InlineData(5, 25, 3.75)]
    public void Apply_Discount(double initialPrice, double discount, double finalPrice)
    {
        var product = new Product(
            Id: Guid.NewGuid().ToString(),
            Name: "Test Product",
            Description: "Some test product.",
            Price: initialPrice
        );

        Assert.Equal(
            expected: finalPrice,
            actual: product.ApplyDiscount(discount).Price
        );
    }
}