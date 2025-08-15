namespace WMS.UI.UseCases.Products.Common;

public record ProductDto(
    Guid? Id,
    string Sku,
    string Name,
    string ManufacturersCode,
    bool IsActive,
    string? Summary,
    decimal Weight,
    string WeightUnit,
    decimal CostPrice,
    decimal SellPrice); 