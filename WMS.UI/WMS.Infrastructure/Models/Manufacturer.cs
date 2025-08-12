using System.ComponentModel.DataAnnotations;

namespace WMS.Infrastructure.Models;

public class Manufacturer
{
    [Key]
    public int Id { get; init; }
    
    [Required]
    public string Name { get; init; } = null!;
    
    // Navigation Properties
    public ICollection<Product> Products { get; init; } = new List<Product>();
}