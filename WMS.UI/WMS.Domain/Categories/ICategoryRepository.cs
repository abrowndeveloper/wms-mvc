namespace WMS.Domain.Categories;

public interface ICategoryRepository
{
    Task UpsertAsync(IReadOnlyList<Category> categories, CancellationToken cancellationToken = default);
}