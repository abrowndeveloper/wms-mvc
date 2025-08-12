namespace WMS.Domain.Categories;

public interface ICategoryRepository
{
    Task Upsert();
}