namespace StockManager.Domain.Models;

public record Product(
    Guid Id,
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
        Price = Price * (1 - discount),
        UpdatedAt = DateTime.Now
    };
}