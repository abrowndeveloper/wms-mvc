namespace WMS.Domain.Products;

public interface IProductService
{
    Task<Product?> GetProductById(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Product>> GetProducts(CancellationToken cancellationToken = default);
    public Task InsertAsync(IReadOnlyList<Product> products, CancellationToken cancellationToken = default);
}