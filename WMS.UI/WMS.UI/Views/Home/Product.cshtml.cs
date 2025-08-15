using WMS.UI.UseCases.Products.Common;

namespace WMS.UI.Views;

public record ProductModel
{
    public Guid? Id { get; init; }
    public string Sku { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string ManufacturersCode { get; init; } = string.Empty;
    public bool IsActive { get; init; }
    public string? Summary { get; init; }
    public decimal Weight { get; init; }
    public string WeightUnit { get; init; } = string.Empty;
    public decimal CostPrice { get; init; }
    public decimal SellPrice { get; init; }
} 