using WMS.Domain.Units;

namespace WMS.UI.UseCases.Products.UpsertProducts.Factories;

public static class ProductRowDtoFactory
{
    public static ProductRowDto CreateRow(RawProductRowDto rawRowDto)
    {
        var invalidCells = new List<InvalidCell>();

        if (string.IsNullOrWhiteSpace(rawRowDto.Sku))
            invalidCells.Add(new(nameof(rawRowDto.Sku), "Sku cannot be null or whitespace"));
 
        if (string.IsNullOrWhiteSpace(rawRowDto.Name))
            invalidCells.Add(new(nameof(rawRowDto.Name), "Name cannot be null or whitespace"));
                
        if (string.IsNullOrWhiteSpace(rawRowDto.ManufacturersCode))
            invalidCells.Add(new(nameof(rawRowDto.ManufacturersCode), "ManufacturersCode cannot be null or whitespace"));
                
        if (rawRowDto.Summary is not null && rawRowDto.Summary.Length >= 1000)
            invalidCells.Add(new(nameof(rawRowDto.Summary), "Summary is too long"));
                
        if (string.IsNullOrWhiteSpace(rawRowDto.Category))
            invalidCells.Add(new(nameof(rawRowDto.Category), "Category cannot be null or whitespace"));
                
        if (string.IsNullOrWhiteSpace(rawRowDto.Manufacturer))
            invalidCells.Add(new(nameof(rawRowDto.Manufacturer), "Manufacturer cannot be null or whitespace"));
                
        if (!DateTime.TryParse(rawRowDto.DateCreated, out var dateTimeCreated))
            invalidCells.Add(new(nameof(rawRowDto.DateCreated), "Invalid DateCreated format"));
                
        if (!DateTime.TryParse(rawRowDto.DateUpdated, out var dateTimeUpdated))
            invalidCells.Add(new(nameof(rawRowDto.DateUpdated), "Invalid DateUpdated format"));

        bool? isActive = rawRowDto.IsActive switch
        {
            "0" => false,
            "1" => true,
            _ => null
        };
        if (isActive is null)
            invalidCells.Add(new(nameof(rawRowDto.IsActive), "Invalid IsActive format"));
                
        if (!decimal.TryParse(rawRowDto.Weight, out var weight))
            invalidCells.Add(new(nameof(rawRowDto.Weight), "Weight must be a positive decimal"));
                
        if (!Enum.TryParse<WeightUnit>(rawRowDto.WeightUnit, out var weightUnit))
            invalidCells.Add(new(nameof(rawRowDto.WeightUnit), "Invalid WeightUnit format"));
                
        if (!decimal.TryParse(rawRowDto.CostPrice, out var costPrice))
            invalidCells.Add(new(nameof(rawRowDto.CostPrice), "Invalid CostPrice format"));
                
        if (!decimal.TryParse(rawRowDto.SellPrice, out var sellPrice))
            invalidCells.Add(new(nameof(rawRowDto.SellPrice), "Invalid SellPrice format"));
                
        if (!int.TryParse(rawRowDto.CategoryID, out var categoryId))
            invalidCells.Add(new(nameof(rawRowDto.CategoryID), "Invalid CategoryId format"));
                
        if (!int.TryParse(rawRowDto.ManufacturerID, out var manufacturerId))
            invalidCells.Add(new(nameof(rawRowDto.ManufacturerID), "Invalid ManufacturerId format"));
                
        if (!int.TryParse(rawRowDto.Qty, out var quantity))
            invalidCells.Add(new(nameof(rawRowDto.Qty), "Invalid Qty format"));

        return new ProductRowDto
        {
            InvalidCells = invalidCells,
            Sku = rawRowDto.Sku!,
            Name = rawRowDto.Name!,
            ManufacturersCode = rawRowDto.ManufacturersCode!,
            Summary = rawRowDto.Summary,
            Category = rawRowDto.Category!,
            Manufacturer = rawRowDto.Manufacturer!,
            DateTimeCreated = dateTimeCreated,
            DateTimeUpdated = dateTimeUpdated,
            IsActive = isActive ?? false,
            Weight = weight,
            WeightUnit = weightUnit,
            CostPrice = costPrice,
            SellPrice = sellPrice,
            CategoryId = categoryId,
            ManufacturerId = manufacturerId,
            Quantity = quantity
        };
    }
}