using System.ComponentModel.DataAnnotations;

namespace WMS.Infrastructure.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Sku { get; set; } = null!;
    
    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = null!;
    
    [Required]
    [MaxLength(255)]
    public string ManufacturersCode { get; set; } = null!;
    
    [Required]
    public DateTime DateTimeCreated { get; set; }
    
    [Required]
    public DateTime DateTimeUpdated { get; set; }
    
    [Required]
    public bool IsActive { get; set; }
    
    public string? Summary { get; set; }
    
    [Required]
    public decimal Weight { get; set; }
    
    [Required]
    public int WeightUnit { get; set; }
    
    [Required]
    public decimal CostPrice { get; set; }
    
    [Required]
    public decimal SellPrice { get; set; }
    
    // Foreign Keys
    [Required]
    public int CategoryId { get; set; }
    
    [Required]
    public int ManufacturerId { get; set; }
    
    [Required]
    public int StockId { get; set; }
} 