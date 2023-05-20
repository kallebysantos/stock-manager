namespace StockManager.Domain.Models;

public record Product(
    string Id,
    string Name,
    string Description,
    double Price,
    ICollection<Supplier> Suppliers
)
{
    public DateTime CreatedAt = DateTime.Now;

    public DateTime UpdatedAt = DateTime.Now;

    public Product ApplyDiscount(double discount) => this with
    {
        Price = Price * (1 - discount / 100),
        UpdatedAt = DateTime.Now
    };
}