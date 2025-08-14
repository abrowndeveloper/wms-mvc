namespace WMS.Domain.Products;

public interface IProductRepository
{
    Task UpsertAsync(IReadOnlyList<Product> products, CancellationToken cancellationToken = default);
}