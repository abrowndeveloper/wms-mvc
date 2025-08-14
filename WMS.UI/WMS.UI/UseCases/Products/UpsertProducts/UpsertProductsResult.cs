namespace WMS.UI.UseCases.Products.UpsertProducts;

public record UpsertProductsResult(
    string? Error, 
    IReadOnlyList<InvalidRow> InvalidRows,
    int SuccessCount);

public record InvalidRow(int RowNumber, IReadOnlyList<InvalidCell> InvalidCells);

public record InvalidCell(string ColumnName, string Reason);

