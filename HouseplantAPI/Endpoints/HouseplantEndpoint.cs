using System;
using HouseplantAPI.Dtos;
using HouseplantAPI.Entities;
using HouseplantAPI.Mappings;
using Microsoft.EntityFrameworkCore;

namespace HouseplantAPI.Endpoints;

public static class HouseplantEndpoint
{
    public static RouteGroupBuilder MapHouseplantEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("houseplant");
        const string GetGameByIdEndpoint = "GetGameById";

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
        }).WithName(GetGameByIdEndpoint);

        group.MapPost("/", async (CreateHouseplantDto createHouseplant, HouseplantApiDbContext dbContext) =>
        {
            Houseplant houseplant = createHouseplant.ToEntity(dbContext);
            dbContext.Houseplants.Add(houseplant);
            await dbContext.SaveChangesAsync();
            return Results.CreatedAtRoute(GetGameByIdEndpoint, new { id = houseplant.Id }, houseplant.ToDto(dbContext));
        });

        group.MapPut("/{id}", async (int id, UpdateHouseplantDto updateHouseplant, HouseplantApiDbContext dbContext) =>
        {
            Houseplant? existingPlant = await dbContext.Houseplants.FindAsync(id);
            if (existingPlant is null)
            {
                return Results.NotFound();
            }
            dbContext.Entry(existingPlant).CurrentValues.SetValues(updateHouseplant.ToEntity(id));
            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        });

        return group;
    }
}
