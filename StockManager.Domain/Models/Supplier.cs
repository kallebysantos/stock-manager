using StockManager.Domain.Types;

namespace StockManager.Domain.Models;

public record Supplier(
    string Id,
    string Name,
    string Email,
    string? Website,
    Address? Address,
    ICollection<PhoneNumber> ContactNumbers
);