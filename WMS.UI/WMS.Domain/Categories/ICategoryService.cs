namespace WMS.Domain.Categories;

public interface ICategoryService
{
    public Task UpsertAsync(IReadOnlyList<Category> categories, CancellationToken cancellationToken = default);
} 