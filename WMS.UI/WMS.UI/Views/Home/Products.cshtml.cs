using WMS.UI.UseCases.Products.GetProducts;

namespace WMS.UI.Views;

public record ProductsModel
{
    public IReadOnlyList<ProductRowDto> Products { get; init; } = [];
}