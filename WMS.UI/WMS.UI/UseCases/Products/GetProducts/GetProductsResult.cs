namespace WMS.UI.UseCases.Products.GetProducts;

public record GetProductsResult(IReadOnlyList<ProductRowDto> Products);

public record ProductRowDto(
    Guid Id,
    string Sku,
    string Name,
    string ManufacturersCode,
    DateTime DateTimeCreated,
    DateTime DateTimeUpdated,
    bool IsActive,
    string? Summary,
    string Weight,
    string CostPrice,
    string SellPrice,
    string MarginAmount,
    string Manufacturer,
    string Category); 