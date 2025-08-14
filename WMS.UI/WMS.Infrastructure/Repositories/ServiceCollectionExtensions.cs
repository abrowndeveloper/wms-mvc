using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WMS.Domain.Categories;
using WMS.Domain.Manufacturers;
using WMS.Domain.Products;
using WMS.Infrastructure.Repositories.Categories;
using WMS.Infrastructure.Repositories.Manufacturers;
using WMS.Infrastructure.Repositories.Products;

namespace WMS.Infrastructure.Repositories;

public static class ServiceCollectionExtensions
{
    // Ideally split out into many functions
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.TryAddTransient<IProductRepository, ProductRepository>();
        services.TryAddTransient<IManufacturerRepository, ManufacturerRepository>();
        services.TryAddTransient<ICategoryRepository, CategoryRepository>();

        return services;
    }
}