using WMS.Domain.Manufacturers;

namespace WMS.Application.Manufacturers;

public class ManufacturerService(
    IManufacturerRepository manufacturerRepository
    ) : IManufacturerService
{
    public async Task UpsertAsync(IReadOnlyList<Manufacturer> manufacturers, CancellationToken cancellationToken = default)
    {
        await manufacturerRepository.UpsertAsync(manufacturers, cancellationToken);
    }
} 