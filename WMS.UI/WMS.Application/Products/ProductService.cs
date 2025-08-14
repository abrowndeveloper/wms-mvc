using WMS.Domain.Products;

namespace WMS.Application.Products;

public class ProductService(
    IProductRepository productRepository
    ) : IProductService
{
    public async Task UpsertAsync(IReadOnlyList<Product> products, CancellationToken cancellationToken = default)
    {
        await productRepository.UpsertAsync(products, cancellationToken);
    }
}