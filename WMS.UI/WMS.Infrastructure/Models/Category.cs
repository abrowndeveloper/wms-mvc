using System.ComponentModel.DataAnnotations;

namespace WMS.Infrastructure.Models;

public class Category
{
    [Key]
    public int Id { get; init; }
    
    [Required]
    [MaxLength(255)]
    public string Name { get; init; } = null!;
    
    // Navigation Properties
    public ICollection<Product> Products { get; init; } = new List<Product>();
} 