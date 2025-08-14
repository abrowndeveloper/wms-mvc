namespace WMS.Domain.Manufacturers;

public interface IManufacturerRepository
{
    Task UpsertAsync(IReadOnlyList<Manufacturer> manufacturers, CancellationToken cancellationToken = default);
}