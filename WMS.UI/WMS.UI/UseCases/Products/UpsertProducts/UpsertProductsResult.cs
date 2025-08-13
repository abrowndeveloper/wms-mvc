namespace WMS.UI.UseCases.Products.UpsertProducts;

public record UpsertProductsResult(
    string? Error, 
    IReadOnlyList<string> InvalidRows,
    int SuccessCount);