using MediatR;
using WMS.Domain.Products;
using WMS.UI.UseCases.Products.Common;

namespace WMS.UI.UseCases.Products.GetProduct;

public class GetProductHandler(IProductService productService) : IRequestHandler<GetProductRequest, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductRequest request, CancellationToken cancellationToken)
    {
        var product = await productService.GetProductById(request.Id, cancellationToken);
        
        if (product is null)
            return new GetProductResult(null);
        
        var dto = new ProductDto(
            product.Id,
            product.Sku,
            product.Name,
            product.ManufacturersCode,
            product.IsActive,
            product.Summary ?? string.Empty,
            product.Weight,
            product.WeightUnit.ToString(),
            product.CostPrice,
            product.SellPrice
        );
        
        return new GetProductResult(dto);
    }
} 