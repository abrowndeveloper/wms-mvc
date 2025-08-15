namespace WMS.UI.UseCases.Products.GetProducts;

public record GetProductsResult(IReadOnlyList<ProductDto> Products);

public record ProductDto(
    Guid Id,
    string Sku,
    string Name,
    string ManufacturersCode,
    DateTime DateTimeCreated,
    DateTime DateTimeUpdated,
    bool IsActive,
    string? Summary,
    decimal Weight,
    string WeightUnit,
    decimal CostPrice,
    decimal SellPrice,
    string Manufacturer,
    string Category); 