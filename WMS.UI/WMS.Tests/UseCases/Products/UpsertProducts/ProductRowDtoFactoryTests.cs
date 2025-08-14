using WMS.UI.UseCases.Products.UpsertProducts;
using WMS.UI.UseCases.Products.UpsertProducts.Factories;
using WMS.Domain.Units;

namespace WMS.Tests.UseCases.Products.UpsertProducts;

public class ProductRowDtoFactoryTests
{
    [Fact]
    public void WhenEverythingIsValid_ThenThereAreNoInvalidRows()
    {
        var row = new RawProductRowDto
        {
            Sku = "ABC123",
            Name = "Special CPU",
            DateCreated = "2024-01-15",
            DateUpdated = "2024-01-16",
            IsActive = "1",
            Summary = "High performance CPU",
            Weight = "2.5",
            ManufacturersCode = "MAN001",
            WeightUnit = "KG",
            CategoryID = "1",
            Category = "Electronics",
            ManufacturerID = "2",
            Manufacturer = "Intel",
            CostPrice = "150.00",
            SellPrice = "299.99",
            Qty = "10"
        };

        var result = ProductRowDtoFactory.CreateRow(row);
        
        Assert.Empty(result.InvalidCells);
        Assert.Equal("ABC123", result.Sku);
        Assert.Equal("Special CPU", result.Name);
        Assert.Equal("MAN001", result.ManufacturersCode);
        Assert.Equal("High performance CPU", result.Summary);
        Assert.Equal("Electronics", result.Category);
        Assert.Equal("Intel", result.Manufacturer);
        Assert.Equal(new DateTime(2024, 1, 15), result.DateTimeCreated);
        Assert.Equal(new DateTime(2024, 1, 16), result.DateTimeUpdated);
        Assert.True(result.IsActive);
        Assert.Equal(2.5m, result.Weight);
        Assert.Equal(WeightUnit.KG, result.WeightUnit);
        Assert.Equal(1, result.CategoryId);
        Assert.Equal(2, result.ManufacturerId);
        Assert.Equal(150.00m, result.CostPrice);
        Assert.Equal(299.99m, result.SellPrice);
        Assert.Equal(10, result.Quantity);
    }

    [Fact]
    public void WhenAllTypesFail_ThenAllInvalidCellsAreReported()
    {
        var row = new RawProductRowDto
        {
            Sku = "",
            Name = "",
            DateCreated = "invalid-date",
            DateUpdated = "not-a-date",
            IsActive = "invalid",
            Summary = "",
            Weight = "not-a-number",
            ManufacturersCode = "",
            WeightUnit = "invalid-unit",
            CategoryID = "not-an-int",
            Category = "",
            ManufacturerID = "also-not-an-int",
            Manufacturer = "",
            CostPrice = "invalid-price",
            SellPrice = "bad-price",
            Qty = "not-quantity"
        };

        var result = ProductRowDtoFactory.CreateRow(row);
        
        Assert.NotEmpty(result.InvalidCells);
        Assert.Equal(16, result.InvalidCells.Count);
        
        Assert.Contains(result.InvalidCells, ic => ic is { ColumnName: "Sku", Reason: "Sku cannot be null or whitespace" });
        Assert.Contains(result.InvalidCells, ic => ic is { ColumnName: "Name", Reason: "Name cannot be null or whitespace" });
        Assert.Contains(result.InvalidCells, ic => ic is { ColumnName: "ManufacturersCode", Reason: "ManufacturersCode cannot be null or whitespace" });
        Assert.Contains(result.InvalidCells, ic => ic is { ColumnName: "Summary", Reason: "Summary cannot be null or whitespace" });
        Assert.Contains(result.InvalidCells, ic => ic is { ColumnName: "Category", Reason: "Category cannot be null or whitespace" });
        Assert.Contains(result.InvalidCells, ic => ic is { ColumnName: "Manufacturer", Reason: "Manufacturer cannot be null or whitespace" });
        Assert.Contains(result.InvalidCells, ic => ic is { ColumnName: "DateCreated", Reason: "Invalid DateCreated format" });
        Assert.Contains(result.InvalidCells, ic => ic is { ColumnName: "DateUpdated", Reason: "Invalid DateUpdated format" });
        Assert.Contains(result.InvalidCells, ic => ic is { ColumnName: "IsActive", Reason: "Invalid IsActive format" });
        Assert.Contains(result.InvalidCells, ic => ic is { ColumnName: "Weight", Reason: "Weight must be a positive decimal" });
        Assert.Contains(result.InvalidCells, ic => ic is { ColumnName: "WeightUnit", Reason: "Invalid WeightUnit format" });
        Assert.Contains(result.InvalidCells, ic => ic is { ColumnName: "CostPrice", Reason: "Invalid CostPrice format" });
        Assert.Contains(result.InvalidCells, ic => ic is { ColumnName: "SellPrice", Reason: "Invalid SellPrice format" });
        Assert.Contains(result.InvalidCells, ic => ic is { ColumnName: "CategoryID", Reason: "Invalid CategoryId format" });
        Assert.Contains(result.InvalidCells, ic => ic is { ColumnName: "ManufacturerID", Reason: "Invalid ManufacturerId format" });
        Assert.Contains(result.InvalidCells, ic => ic is { ColumnName: "Qty", Reason: "Invalid Qty format" });
    }
}