using WMS.Domain.Categories;

namespace WMS.Application.Categories;

public class CategoryService(
    ICategoryRepository categoryRepository
    ) : ICategoryService
{
    public async Task<IReadOnlyList<Category>> GetCategoriesByIdsAsync(IReadOnlyList<int> categoryIds, CancellationToken cancellationToken = default)
    {
        return await categoryRepository.GetCategoriesByIdsAsync(categoryIds, cancellationToken);
    }

    public async Task InsertAsync(IReadOnlyList<Category> categories, CancellationToken cancellationToken = default)
    {
        await categoryRepository.UpsertAsync(categories, cancellationToken);
    }
} 