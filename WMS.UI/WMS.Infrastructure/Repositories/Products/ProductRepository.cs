using Microsoft.EntityFrameworkCore;
using WMS.Domain.Products;
using WMS.Domain.Units;
using WMS.Infrastructure.Data;
using DbProduct = WMS.Infrastructure.Models.Product;

namespace WMS.Infrastructure.Repositories.Products;

public class ProductRepository(
    WmsDbContext dbContext
    ) : IProductRepository
{
    public async Task<Product?> GetProductById(Guid id, CancellationToken cancellationToken = default)
    {
        var dbProduct = await dbContext.Products
            .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
        
        if (dbProduct is null)
            return null;
        
        return new Product
        {
            Id = dbProduct.Id,
            Sku = dbProduct.Sku,
            CategoryId = dbProduct.CategoryId,
            CostPrice = dbProduct.CostPrice,
            DateTimeCreated = dbProduct.DateTimeCreated,
            DateTimeUpdated = dbProduct.DateTimeUpdated,
            IsActive = dbProduct.IsActive,
            ManufacturerId = dbProduct.ManufacturerId,
            Name = dbProduct.Name,
            ManufacturersCode = dbProduct.ManufacturersCode,
            SellPrice = dbProduct.SellPrice,
            Summary = dbProduct.Summary,
            Weight = dbProduct.Weight,
            WeightUnit = (WeightUnit)dbProduct.WeightUnit
        };
    }
    
    public async Task<IReadOnlyList<Product>> GetProducts(CancellationToken cancellationToken = default)
    {
        var existingProducts = await dbContext.Products
            .ToArrayAsync(cancellationToken);
        
        return existingProducts
            .Select(product => new Product
            {
                Id = product.Id,
                Sku = product.Sku,
                CategoryId = product.CategoryId,
                CostPrice = product.CostPrice,
                DateTimeCreated = product.DateTimeCreated,
                DateTimeUpdated = product.DateTimeUpdated,
                IsActive = product.IsActive,
                ManufacturerId = product.ManufacturerId,
                Name = product.Name,
                ManufacturersCode = product.ManufacturersCode,
                SellPrice = product.SellPrice,
                Summary = product.Summary,
                Weight = product.Weight,
                WeightUnit = (WeightUnit)product.WeightUnit
            })
            .ToArray();
    }
    
    public async Task Insert(IReadOnlyList<Product> products, CancellationToken cancellationToken)
    {
        var models = products
            .Select(p => new DbProduct
            {
                Id = p.Id,
                Sku = p.Sku,
                Name = p.Name,
                ManufacturersCode = p.ManufacturersCode,
                DateTimeCreated = DateTime.UtcNow,
                DateTimeUpdated = DateTime.UtcNow,
                IsActive = p.IsActive,
                Summary = p.Summary,
                Weight = p.Weight,
                WeightUnit = (int)p.WeightUnit,
                CostPrice = p.CostPrice,
                SellPrice = p.SellPrice,
                CategoryId = p.CategoryId,
                ManufacturerId = p.ManufacturerId,
            })
            .ToArray();
        
        await dbContext.Products.AddRangeAsync(models, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}