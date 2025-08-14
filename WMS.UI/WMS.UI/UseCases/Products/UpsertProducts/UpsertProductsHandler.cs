using CsvHelper;
using MediatR;
using WMS.Domain.Products;
using WMS.Domain.Categories;
using WMS.Domain.Manufacturers;
using System.Globalization;
using WMS.UI.UseCases.Products.UpsertProducts.Factories;

namespace WMS.UI.UseCases.Products.UpsertProducts;

public record RawProductRowDto
{
    public string? Sku { get; init; }
    public string? Name { get; init; }
    public string? DateCreated { get; init; }
    public string? DateUpdated { get; init; }
    public string? IsActive { get; init; }
    public string? Summary { get; init; }
    public string? Weight { get; init; }
    public string? ManufacturersCode { get; init; }
    public string? WeightUnit { get; init; }
    public string? CategoryID { get; init; }
    public string? Category { get; init; }
    public string? ManufacturerID { get; init; }
    public string? Manufacturer { get; init; }
    public string? CostPrice { get; init; }
    public string? SellPrice { get; init; }
    public string? Qty { get; init; }
}

public class UpsertProductsHandler(
    IProductService productService,
    ICategoryService categoryService,
    IManufacturerService manufacturerService) : IRequestHandler<UpsertProductsRequest, UpsertProductsResult>
{
    public async Task<UpsertProductsResult> Handle(UpsertProductsRequest request, CancellationToken cancellationToken)
    {
        var products = new List<Product>();
        var categories = new List<Category>();
        var manufacturers = new List<Manufacturer>();
        var invalidRows = new List<InvalidRow>();

        try
        {
            using var reader = new StreamReader(request.ProductsFile.OpenReadStream());
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            foreach (var rawRow in csv.GetRecords<RawProductRowDto>())
            {
                var row = ProductRowDtoFactory.CreateRow(rawRow);

                if (!row.InvalidCells.Any())
                {
                    products.Add(new Product
                    {
                        Id = new Random().Next(1, int.MaxValue), // TBC, temporary
                        Sku = row.Sku,
                        Name = row.Name,
                        ManufacturersCode = row.ManufacturersCode,
                        Summary = row.Summary,
                        CategoryId = row.CategoryId,
                        ManufacturerId = row.ManufacturerId,
                        DateTimeCreated = row.DateTimeCreated,
                        DateTimeUpdated = row.DateTimeUpdated,
                        IsActive = row.IsActive,
                        Weight = row.Weight,
                        WeightUnit = row.WeightUnit,
                        CostPrice = row.CostPrice,
                        SellPrice = row.SellPrice
                    });

                    if (categories.All(c => c.Id != row.CategoryId))
                    {
                        categories.Add(new Category
                        {
                            Id = row.CategoryId,
                            Name = row.Category,
                        });
                    }
                    
                    if (manufacturers.All(c => c.Id != row.ManufacturerId))
                    {
                        manufacturers.Add(new Manufacturer
                        {
                            Id = row.ManufacturerId,
                            Name = row.Manufacturer,
                        });
                    }
                }
                else
                    invalidRows.Add(new InvalidRow(csv.Context.Parser.Row - 1, row.InvalidCells));
            }
        }
        catch
        {
            return new("An error occurred while processing the CSV file.", [], 0);
        }

        if (!request.SkipErrors && invalidRows.Any())
            return new(null, invalidRows, 0);

        if (categories.Any())
            await categoryService.UpsertAsync(categories, cancellationToken);

        if (manufacturers.Any())
            await manufacturerService.UpsertAsync(manufacturers, cancellationToken);
        
        if (products.Any())
            await productService.UpsertAsync(products, cancellationToken);

        return new(null, [], products.Count);
    }
}

/* ConvertRulesValidation:
 * DomainRulesValidation:
 * Grouping by SKU should give a unique amount of 1 item per group
 * Is Manufacturer-code unique?
 * DateCreated should be before DateUpdated
 * Weight unit should be valid enum (WeightUnit)
 * Weight should be > 0
 * CategoryID should be unique per name
 * ManufacturerID should be unique per name
 * CostPrice and SellPrice should be more than 0.
 * Qty should be > -1
 * On re-upload a category name and manufacturer name shouldn't be changeable
 */

// EXTRAS:
// What happens if a user re-uploads with same data, and different data on another?
// Work out which to create and which to update