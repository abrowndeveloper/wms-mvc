using Microsoft.EntityFrameworkCore;
using WMS.Infrastructure.Models;

namespace WMS.Infrastructure.Data;

public class WmsDbContext(
    DbContextOptions<WmsDbContext> options
    ) : DbContext(options)
{
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Stock> Stocks { get; set; }
}