namespace WMS.Domain.Manufacturers;

public interface IManufacturerService
{
    public Task UpsertAsync(IReadOnlyList<Manufacturer> manufacturers, CancellationToken cancellationToken = default);
} 