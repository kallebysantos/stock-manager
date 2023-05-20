using System.ComponentModel.DataAnnotations;

namespace StockManager.Domain.Contracts.Payloads.Product;

public record CreateProductPayload
(
    [Required]
    string? Name,

    [Required]
    string? Description,

    [Required]
    double? Price
);