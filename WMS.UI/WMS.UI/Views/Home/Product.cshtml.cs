using WMS.UI.UseCases.Products.GetProduct;

namespace WMS.UI.Views;

public record ProductModel
{
    public required ProductDto Product { get; init; }
} 