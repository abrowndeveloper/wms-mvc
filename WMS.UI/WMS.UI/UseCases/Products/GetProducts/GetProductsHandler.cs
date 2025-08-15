using MediatR;
using WMS.Domain.Categories;
using WMS.Domain.Manufacturers;
using WMS.Domain.Products;
using WMS.UI.UseCases.Products.GetProducts;

namespace WMS.UI.UseCases.Products.GetProducts;

public class GetProductsHandler(
    IProductService productService,
    IManufacturerService manufacturerService,
    ICategoryService categoryService) : IRequestHandler<GetProductsRequest, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await productService.GetAllAsync(cancellationToken);

        var manufacturerIds = products
            .Select(p => p.ManufacturerId)
            .Distinct()
            .ToArray();
        
        var manufacturers = await manufacturerService.GetManufacturersByIdsAsync(manufacturerIds, cancellationToken);
        
        var categoryIds = products
            .Select(p => p.CategoryId)
            .Distinct()
            .ToArray();
        
        var categories = await categoryService.GetCategoriesByIdsAsync(categoryIds, cancellationToken);
        
        var productDtos = products
            .Select(product => ToProductDto(product, manufacturers, categories))
            .ToArray();

        return new GetProductsResult(productDtos);
    }

    private ProductDto ToProductDto(Product product, IReadOnlyList<Manufacturer> manufacturers, IReadOnlyList<Category> categories)
    {
        var margin = product.SellPrice - product.CostPrice;
        
        return new ProductDto(
            product.Id,
            product.Sku,
            product.Name,
            product.ManufacturersCode,
            product.DateTimeCreated,
            product.DateTimeUpdated,
            product.IsActive,
            product.Summary,
            $"{product.Weight} {product.WeightUnit}",
            ToGbp(product.CostPrice),
            ToGbp(product.SellPrice),
            ToGbp(margin),
            manufacturers.Single(m => m.Id == product.ManufacturerId).Name,
            categories.Single(c => c.Id == product.CategoryId).Name
        );
    }

    private string ToGbp(decimal price)
    {
        return Math.Round(price, 2, MidpointRounding.AwayFromZero)
            .ToString("C2", new System.Globalization.CultureInfo("en-GB"));
    }
}