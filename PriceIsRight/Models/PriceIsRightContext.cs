using Microsoft.EntityFrameworkCore;

public class PriceIsRightContext : DbContext
{
    public PriceIsRightContext(DbContextOptions<PriceIsRightContext> options) : base(options)
    {
        
    }
    public DbSet<Prize> Prizes { get; set; }

}