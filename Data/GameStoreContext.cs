namespace GameStore.Data;

using Microsoft.EntityFrameworkCore;
using GameStore.Entities;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new { Id = 1, Name = "Action"},
            new { Id = 2, Name = "Adventure"},
            new { Id = 3, Name = "RPG"},
            new { Id = 4, Name = "MMO"},
            new { Id = 5, Name = "Strategy"},
            new { Id = 6, Name = "Shooter"},
            new { Id = 7, Name = "Run and Gun"}
        );
    }
}