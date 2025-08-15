using WMS.Domain.Categories;
using WMS.Infrastructure.Data;
using DbCategory = WMS.Infrastructure.Models.Category;

namespace WMS.Infrastructure.Repositories.Categories;

public class CategoryRepository(
    WmsDbContext dbContext
) : ICategoryRepository
{
    public async Task UpsertAsync(IReadOnlyList<Category> categories, CancellationToken cancellationToken = default)
    {
        // TODO: Make upsert actually upsert.
        
        var models = categories
            .Select(c => new DbCategory
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToArray();
        
        await dbContext.Categories.AddRangeAsync(models, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}