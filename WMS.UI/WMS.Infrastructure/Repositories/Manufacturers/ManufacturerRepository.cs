using WMS.Domain.Manufacturers;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.Manufacturers;

public class ManufacturerRepository(
    WmsDbContext dbContext
    ) : IManufacturerRepository
{
    public async Task UpsertAsync(IReadOnlyList<Manufacturer> manufacturers, CancellationToken cancellationToken = default)
    {
        // TODO: Make upsert actually upsert.
        await dbContext.AddRangeAsync(manufacturers, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}