using WMS.UI.UseCases.Products.Common;

namespace WMS.UI.UseCases.Products.UpsertProduct;

public record UpsertProductResult(string? Error, ProductDto? Product); 