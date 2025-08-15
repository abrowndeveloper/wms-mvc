namespace WMS.Domain.Manufacturers;

public interface IManufacturerService
{
    Task<IReadOnlyList<Manufacturer>> GetManufacturersByIdsAsync(IReadOnlyList<int> manufacturerIds, CancellationToken cancellationToken = default);
    public Task InsertAsync(IReadOnlyList<Manufacturer> manufacturers, CancellationToken cancellationToken = default);
} 