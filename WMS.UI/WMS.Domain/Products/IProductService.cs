namespace WMS.Domain.Products;

public interface IProductService
{
    Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default);
    public Task InsertAsync(IReadOnlyList<Product> products, CancellationToken cancellationToken = default);
}