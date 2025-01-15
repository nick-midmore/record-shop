using Microsoft.EntityFrameworkCore;
using RecordShop.Models.Entities;

namespace RecordShop;

public class ShopContext : DbContext
{
    public DbSet<Album> Albums { get; set; }
    public DbSet<Stock> Stock { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configBuilder = new ConfigurationBuilder();
        var config = configBuilder.AddUserSecrets<ShopContext>().Build();
        string? connection = config.GetSection("SQLSERVER")["connectionString"];
        optionsBuilder.UseSqlServer(connection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>()
            .HasOne(a => a.Stock)
            .WithOne(s => s.Album)
            .HasForeignKey<Stock>(s => s.AlbumId);
        base.OnModelCreating(modelBuilder);
    }
}
