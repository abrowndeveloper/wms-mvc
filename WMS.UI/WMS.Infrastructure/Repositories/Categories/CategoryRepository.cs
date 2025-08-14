using WMS.Domain.Categories;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.Categories;

public class CategoryRepository(
    WmsDbContext dbContext
) : ICategoryRepository
{
    public async Task UpsertAsync(IReadOnlyList<Category> categories, CancellationToken cancellationToken = default)
    {
        // TODO: Make upsert actually upsert.
        await dbContext.AddRangeAsync(categories, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}