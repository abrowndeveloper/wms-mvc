using Microsoft.EntityFrameworkCore;

namespace WMS.Infrastructure.Data;

public class WmsDbContext(
    DbContextOptions<WmsDbContext> options
    ) : DbContext(options)
{

}