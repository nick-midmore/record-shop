using Microsoft.EntityFrameworkCore;
using RecordShop.Models;

namespace RecordShop;

public class ShopContext : DbContext
{
    public DbSet<Album> Albums { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
