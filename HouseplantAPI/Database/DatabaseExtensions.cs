using System;
using Microsoft.EntityFrameworkCore;

namespace HouseplantAPI.Database;

public static class DatabaseExtensions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<HouseplantApiDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}
