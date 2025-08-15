using Microsoft.EntityFrameworkCore;
using WMS.Domain.Categories;
using WMS.Infrastructure.Data;
using DbCategory = WMS.Infrastructure.Models.Category;

namespace WMS.Infrastructure.Repositories.Categories;

public class CategoryRepository(
    WmsDbContext dbContext
) : ICategoryRepository
{
    public async Task<IReadOnlyList<Category>> GetCategoriesByIdsAsync(IReadOnlyList<int> categoryIds, CancellationToken cancellationToken = default)
    {
        var dbCategories = await dbContext.Categories
            .Where(c => categoryIds.Contains(c.Id))
            .ToArrayAsync(cancellationToken);

        return dbCategories
            .Select(c => new Category
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToArray();
    }

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