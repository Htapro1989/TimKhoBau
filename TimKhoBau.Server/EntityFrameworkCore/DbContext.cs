using Microsoft.EntityFrameworkCore;
using TimKhoBau.Server.Model;

public class TreasureContext : DbContext
{
    public DbSet<TreasureMap> TreasureMaps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=treasure.db");
    }
}