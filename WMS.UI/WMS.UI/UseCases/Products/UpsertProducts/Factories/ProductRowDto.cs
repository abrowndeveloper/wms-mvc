using WMS.Domain.Units;

namespace WMS.UI.UseCases.Products.UpsertProducts.Factories;

public record ProductRowDto
{
    public IReadOnlyList<InvalidCell> InvalidCells { get; init; } = new List<InvalidCell>();
    public string Name { get; init; } = string.Empty;
    public string Sku { get; init; } = string.Empty;
    public string ManufacturersCode { get; init; } = string.Empty;
    public DateTime DateTimeCreated { get; init; }
    public DateTime DateTimeUpdated { get; init; }
    public bool IsActive { get; init; }
    public string? Summary { get; init; }
    public decimal Weight { get; init; }
    public WeightUnit WeightUnit { get; init; }
    public int CategoryId { get; init; }
    public string Category { get; init; } = string.Empty;
    public int ManufacturerId { get; init; }
    public string Manufacturer { get; init; } = string.Empty;
    public decimal CostPrice { get; init; }
    public decimal SellPrice { get; init; }
    public int Quantity { get; init; }
}