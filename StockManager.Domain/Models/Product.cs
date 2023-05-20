namespace StockManager.Domain.Models;

public record Product(
    string Id,
    string Name,
    string Description,
    double Price
)
{
    public ICollection<Supplier> Suppliers { get; } = new HashSet<Supplier>();

    public DateTime CreatedAt { get; } = DateTime.Now;

    public DateTime UpdatedAt { get; private set; } = DateTime.Now;

    public Product ApplyDiscount(double discount) => this with
    {
        Price = Price * (1 - discount / 100),
        UpdatedAt = DateTime.Now
    };

    public void AssociateSupplier(Supplier supplier)
    {
        if (!Suppliers.Contains(supplier))
        {
            Suppliers.Add(supplier);
            supplier.AddProduct(this);
        }
    }
}