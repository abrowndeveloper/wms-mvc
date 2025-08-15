namespace WMS.Domain.Categories;

public interface ICategoryService
{
    public Task InsertAsync(IReadOnlyList<Category> categories, CancellationToken cancellationToken = default);
    public Task<IReadOnlyList<Category>> GetCategoriesByIdsAsync(IReadOnlyList<int> categoryIds, CancellationToken cancellationToken = default);
} 