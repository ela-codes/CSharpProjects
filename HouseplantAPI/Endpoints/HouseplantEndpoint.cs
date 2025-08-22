using System;
using HouseplantAPI.Entities;
using HouseplantAPI.Mappings;
using Microsoft.EntityFrameworkCore;

namespace HouseplantAPI.Endpoints;

public static class HouseplantEndpoint
{
    public static RouteGroupBuilder MapHouseplantEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("houseplant");

        group.MapGet("/", async (HouseplantApiDbContext dbContext) =>
        {
            return await dbContext.Houseplants
            .Select(plant => plant.ToDto(dbContext))
            .AsNoTracking()
            .ToListAsync();
        });

        group.MapGet("/{id}", async (int id, HouseplantApiDbContext dbContext) =>
        {
            Houseplant? foundPlant = await dbContext.Houseplants.FindAsync(id);
            return foundPlant is null
            ? Results.NotFound() 
            : Results.Ok(foundPlant.ToDto(dbContext));
        });


        return group;
    }
}
