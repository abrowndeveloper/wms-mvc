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
        
        var productDtos = products.Select(p => new ProductDto(
            p.Id,
            p.Sku,
            p.Name,
            p.ManufacturersCode,
            p.DateTimeCreated,
            p.DateTimeUpdated,
            p.IsActive,
            p.Summary,
            p.Weight,
            p.WeightUnit.ToString(),
            p.CostPrice,
            p.SellPrice,
            manufacturers.Single(m => m.Id == p.ManufacturerId).Name,
            categories.Single(c => c.Id == p.CategoryId).Name
        )).ToArray();

        return new GetProductsResult(productDtos);
    }
}