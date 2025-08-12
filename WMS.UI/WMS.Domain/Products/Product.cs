namespace WMS.Domain.Products;

public record Product(
    int Id,
    string Sku,
    string Name,
    string ManufacturersCode,
    DateTime DateTimeCreated,
    DateTime DateTimeUpdated,
    bool IsActive,
    string? Summary,
    decimal Weight,
    int WeightUnit,
    decimal CostPrice,
    decimal SellPrice);











