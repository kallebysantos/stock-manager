namespace StockManager.Domain.Models;

public record Product(
    Guid Id,
    string Name,
    string Description,
    double Price,
    DateTime CreatedAt
)
{ }