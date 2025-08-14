using WMS.Domain.Manufacturers;
using WMS.Infrastructure.Data;
using DbManufacturer = WMS.Infrastructure.Models.Manufacturer;

namespace WMS.Infrastructure.Repositories.Manufacturers;

public class ManufacturerRepository(
    WmsDbContext dbContext
    ) : IManufacturerRepository
{
    public async Task UpsertAsync(IReadOnlyList<Manufacturer> manufacturers, CancellationToken cancellationToken = default)
    {
        // TODO: Make upsert actually upsert.
        
        var models = manufacturers
            .Select(m => new DbManufacturer
            {
                Name = m.Name
            })
            .ToArray();
        
        await dbContext.Manufacturers.AddRangeAsync(models, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}