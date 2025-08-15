using WMS.Domain.Units;

namespace WMS.Domain.Products;

public record Product
{
    public Guid Id { get; init; }
    public string Sku { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string ManufacturersCode { get; init; } = string.Empty;
    public DateTime DateTimeCreated { get; init; }
    public DateTime DateTimeUpdated { get; init; }
    public bool IsActive { get; init; }
    public string? Summary { get; init; }
    public decimal Weight { get; init; }
    public WeightUnit WeightUnit { get; init; }
    public decimal CostPrice { get; init; }
    public decimal SellPrice { get; init; }
    public int ManufacturerId { get; init; }
    public int CategoryId { get; init; }
}