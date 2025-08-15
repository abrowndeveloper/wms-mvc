using WMS.Domain.Categories;

namespace WMS.Application.Categories;

public class CategoryService(
    ICategoryRepository categoryRepository
    ) : ICategoryService
{
    public async Task InsertAsync(IReadOnlyList<Category> categories, CancellationToken cancellationToken = default)
    {
        await categoryRepository.UpsertAsync(categories, cancellationToken);
    }
} 