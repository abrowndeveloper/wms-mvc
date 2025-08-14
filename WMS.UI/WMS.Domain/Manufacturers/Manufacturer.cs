namespace WMS.Domain.Manufacturers;

public record Manufacturer
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
}