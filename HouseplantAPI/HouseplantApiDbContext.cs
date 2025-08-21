using HouseplantAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace HouseplantAPI;

public class HouseplantApiDbContext(DbContextOptions<HouseplantApiDbContext> options) : DbContext(options)
{
    public DbSet<Houseplant> Houseplants => Set<Houseplant>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new { Id = 1, Name = "Foliage" },
            new { Id = 2, Name = "Flowering" },
            new { Id = 3, Name = "Succulent" },
            new { Id = 4, Name = "Cacti" }
        );

        modelBuilder.Entity<Houseplant>().HasData(
            new { Id = 1, Name = "Monstera", Leaves = 3, CategoryId = 1}
        );
    }

}
