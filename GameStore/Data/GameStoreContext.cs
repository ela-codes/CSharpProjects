using System;
using GameStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;

// contains all data needed to connect to the database
public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games { get; set; }
}
