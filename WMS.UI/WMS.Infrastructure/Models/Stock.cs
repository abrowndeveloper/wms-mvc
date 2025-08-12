using System.ComponentModel.DataAnnotations;

namespace WMS.Infrastructure.Models;

public class Stock
{
    [Key]
    public int Id { get; init; }
    
    [Required]
    public int Amount { get; init; }
    
    // Navigation Properties
    public ICollection<Product> Products { get; init; } = new List<Product>();
} 