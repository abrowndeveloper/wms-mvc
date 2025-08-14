using WMS.Domain.Products;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.Products;

public class ProductRepository(
    WmsDbContext dbContext
    ) : IProductRepository
{
    public async Task UpsertAsync(IReadOnlyList<Product> products, CancellationToken cancellationToken)
    {
        // TODO: Make upsert actually upsert.
        await dbContext.AddRangeAsync(products, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}