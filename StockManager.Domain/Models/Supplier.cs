using StockManager.Domain.Types;

namespace StockManager.Domain.Models;

public record Supplier(
    string Id,
    string Name,
    string Email,
    string? Website,
    Address? Address,
    ICollection<PhoneNumber> ContactNumbers
)
{
    public ICollection<Product> Products { get; } = new HashSet<Product>();

    public void AddProduct(Product product)
    {
        if (!Products.Contains(product))
        {
            Products.Add(product);
            product.AssociateSupplier(this);
        }
    }
}