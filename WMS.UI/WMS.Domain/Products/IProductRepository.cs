namespace WMS.Domain.Products;

public interface IProductRepository
{
    Task<Product?> GetProductById(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Product>> GetProducts(CancellationToken cancellationToken = default);
    Task Insert(IReadOnlyList<Product> products, CancellationToken cancellationToken = default);
    Task Update(IReadOnlyList<Product> products, CancellationToken cancellationToken = default);
}