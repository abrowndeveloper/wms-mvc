namespace WMS.Domain.Products;

public interface IProductService
{
    public Task UpsertAsync(IReadOnlyList<Product> products, CancellationToken cancellationToken = default);
}