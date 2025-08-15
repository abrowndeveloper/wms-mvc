using Microsoft.EntityFrameworkCore;
using WMS.Domain.Manufacturers;
using WMS.Infrastructure.Data;
using DbManufacturer = WMS.Infrastructure.Models.Manufacturer;

namespace WMS.Infrastructure.Repositories.Manufacturers;

public class ManufacturerRepository(
    WmsDbContext dbContext
    ) : IManufacturerRepository
{
    public async Task<IReadOnlyList<Manufacturer>> GetManufacturersByIdsAsync(IReadOnlyList<int> manufacturerIds, CancellationToken cancellationToken = default)
    {
        var dbManufacturers = await dbContext.Manufacturers
            .Where(m => manufacturerIds.Contains(m.Id))
            .ToArrayAsync(cancellationToken);

        return dbManufacturers
            .Select(m => new Manufacturer
            {
                Id = m.Id,
                Name = m.Name,
            })
            .ToArray();
    }
    
    public async Task InsertAsync(IReadOnlyList<Manufacturer> manufacturers, CancellationToken cancellationToken = default)
    {
        var models = manufacturers
            .Select(m => new DbManufacturer
            {
                Id = m.Id,
                Name = m.Name
            })
            .ToArray();
        
        await dbContext.Manufacturers.AddRangeAsync(models, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}