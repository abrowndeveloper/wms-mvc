using WMS.Domain.Products;

namespace WMS.Application.Products;

public class ProductService(
    IProductRepository productRepository
    ) : IProductService
{
    public async Task<Product?> GetProductById(Guid id, CancellationToken cancellationToken = default)
    {
        return await productRepository.GetProductById(id, cancellationToken);
    }
    public async Task<IReadOnlyList<Product>> GetProducts(CancellationToken cancellationToken = default)
    {
        return await productRepository.GetProducts(cancellationToken);
    }
    public async Task InsertAsync(IReadOnlyList<Product> products, CancellationToken cancellationToken = default)
    {
        await productRepository.Insert(products, cancellationToken);
    }
    
    public async Task UpdateAsync(IReadOnlyList<Product> products, CancellationToken cancellationToken = default)
    {
        await productRepository.Update(products, cancellationToken);
    }
}