using WMS.Domain.Products;
using WMS.Infrastructure.Data;
using DbProduct = WMS.Infrastructure.Models.Product;

namespace WMS.Infrastructure.Repositories.Products;

public class ProductRepository(
    WmsDbContext dbContext
    ) : IProductRepository
{
    public async Task UpsertAsync(IReadOnlyList<Product> products, CancellationToken cancellationToken)
    {
        // TODO: Make upsert actually upsert.

        var models = products
            .Select(p => new DbProduct
            {
                Sku = p.Sku,
                Name = p.Name,
                ManufacturersCode = p.ManufacturersCode,
                DateTimeCreated = DateTime.UtcNow,
                DateTimeUpdated = DateTime.UtcNow,
                IsActive = p.IsActive,
                Summary = p.Summary,
                Weight = p.Weight,
                WeightUnit = (int)p.WeightUnit,
                CostPrice = p.CostPrice,
                SellPrice = p.SellPrice,
                CategoryId = p.CategoryId,
                ManufacturerId = p.ManufacturerId,
            })
            .ToArray();
        
        await dbContext.Products.AddRangeAsync(models, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}