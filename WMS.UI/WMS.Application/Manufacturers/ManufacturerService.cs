using WMS.Domain.Manufacturers;

namespace WMS.Application.Manufacturers;

public class ManufacturerService(
    IManufacturerRepository manufacturerRepository
    ) : IManufacturerService
{
    public async Task<IReadOnlyList<Manufacturer>> GetManufacturersByIdsAsync(IReadOnlyList<int> manufacturerIds, CancellationToken cancellationToken = default)
    {
        return await manufacturerRepository.GetManufacturersByIdsAsync(manufacturerIds, cancellationToken);
    }
    public async Task InsertAsync(IReadOnlyList<Manufacturer> manufacturers, CancellationToken cancellationToken = default)
    {
        await manufacturerRepository.InsertAsync(manufacturers, cancellationToken);
    }
} 