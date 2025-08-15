using MediatR;
using WMS.Domain.Products;
using WMS.Domain.Units;
using WMS.UI.UseCases.Products.UpsertProduct;

namespace WMS.UI.UseCases.Products.UpsertProduct;

public class UpsertProductHandler(
    IProductService productService
    ) : IRequestHandler<UpsertProductRequest, UpsertProductResult>
{
    public async Task<UpsertProductResult> Handle(UpsertProductRequest request, CancellationToken cancellationToken)
    {
        var existingProduct = request.Product.Id.HasValue
            ? await productService.GetProductById(request.Product.Id.Value, cancellationToken)
            : null;
        
        var product = existingProduct is null
            ? new Product
            {
                Id = Guid.NewGuid(),
                SellPrice = request.Product.SellPrice,
                WeightUnit = Enum.Parse<WeightUnit>(request.Product.WeightUnit),
                ManufacturerId = 0,
                CategoryId = 0,
                Summary = request.Product.Summary,
                CostPrice = request.Product.CostPrice,
                DateTimeCreated = DateTime.UtcNow,
                DateTimeUpdated = DateTime.UtcNow,
                IsActive = request.Product.IsActive,
                ManufacturersCode = request.Product.ManufacturersCode,
                Name = request.Product.Name,
                Sku = request.Product.Sku,
                Weight = request.Product.Weight
            }
            : existingProduct with
            {
                SellPrice = request.Product.SellPrice,
                WeightUnit = Enum.Parse<WeightUnit>(request.Product.WeightUnit),
                Summary = request.Product.Summary,
                CostPrice = request.Product.CostPrice,
                DateTimeUpdated = DateTime.UtcNow,
                IsActive = request.Product.IsActive,
                ManufacturersCode = request.Product.ManufacturersCode,
                Name = request.Product.Name,
                Sku = request.Product.Sku,
                Weight = request.Product.Weight
            };
        
        // Domain validation required.

        existingProduct is null
            ? await productService.InsertAsync([product], cancellationToken)
            : await productService.UpdateAsync(product, cancellationToken);

        return new(null, product);
    }
} 