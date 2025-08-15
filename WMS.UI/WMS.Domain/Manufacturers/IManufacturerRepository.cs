namespace WMS.Domain.Manufacturers;

public interface IManufacturerRepository
{
    Task<IReadOnlyList<Manufacturer>> GetManufacturersByIdsAsync(IReadOnlyList<int> manufacturerIds, CancellationToken cancellationToken = default);
    Task InsertAsync(IReadOnlyList<Manufacturer> manufacturers, CancellationToken cancellationToken = default);
}