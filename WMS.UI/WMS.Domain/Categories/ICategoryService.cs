namespace WMS.Domain.Categories;

public interface ICategoryService
{
    public Task InsertAsync(IReadOnlyList<Category> categories, CancellationToken cancellationToken = default);
} 