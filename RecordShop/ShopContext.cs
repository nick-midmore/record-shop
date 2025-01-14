using Microsoft.EntityFrameworkCore;
using RecordShop.Models;

namespace RecordShop;

public class ShopContext : DbContext
{
    public DbSet<Album> Albums { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configBuilder = new ConfigurationBuilder();
        var config = configBuilder.AddUserSecrets<ShopContext>().Build();
        string? connection = config.GetSection("SQLSERVER")["connectionString"];
        optionsBuilder.UseSqlServer(connection);
    }
}
