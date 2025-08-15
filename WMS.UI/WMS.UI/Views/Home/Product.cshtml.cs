using WMS.UI.UseCases.Products.Common;

namespace WMS.UI.Views;

public record ProductModel
{
    public required ProductDto Product { get; init; }
} 