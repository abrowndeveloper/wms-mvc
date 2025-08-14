using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WMS.Application.Categories;
using WMS.Application.Manufacturers;
using WMS.Application.Products;
using WMS.Domain.Categories;
using WMS.Domain.Manufacturers;
using WMS.Domain.Products;

namespace WMS.Application;

public static class ServiceCollectionExtensions
{
    // Ideally split out into many functions
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.TryAddTransient<IProductService, ProductService>();
        services.TryAddTransient<IManufacturerService, ManufacturerService>();
        services.TryAddTransient<ICategoryService, CategoryService>();

        return services;
    }
}