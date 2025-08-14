using WMS.UI.UseCases.Products.UpsertProducts;

namespace WMS.UI.Views;

public class UploadProductsModel
{
    public IReadOnlyList<InvalidRow> InvalidRows { get; init; } = [];
    public string? Error { get; init; }
}