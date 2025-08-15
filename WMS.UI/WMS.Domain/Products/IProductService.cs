namespace WMS.Domain.Products;

public interface IProductService
{
    Task<IReadOnlyList<Product>> GetBySkusAsync(IReadOnlyCollection<string> skus, CancellationToken cancellationToken = default);
    public Task InsertAsync(IReadOnlyList<Product> products, CancellationToken cancellationToken = default);
}