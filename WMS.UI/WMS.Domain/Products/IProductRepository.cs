namespace WMS.Domain.Products;

public interface IProductRepository
{
    Task<IReadOnlyList<Product>> GetProducts(CancellationToken cancellationToken = default);
    Task Insert(IReadOnlyList<Product> products, CancellationToken cancellationToken = default);
}