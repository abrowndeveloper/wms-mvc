namespace WMS.Domain.Manufacturers;

public interface IManufacturerService
{
    public Task InsertAsync(IReadOnlyList<Manufacturer> manufacturers, CancellationToken cancellationToken = default);
} 