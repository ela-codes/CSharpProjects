using System;
using HouseplantAPI.Dtos;
using HouseplantAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace HouseplantAPI.Mappings;

public static class HouseplantMapping
{
    public static Houseplant ToEntity(this HouseplantDto houseplantDto)
    {
        return new Houseplant()
        {
            Id = houseplantDto.Id,
            Name = houseplantDto.Name,
            Leaves = houseplantDto.Leaves,
            CategoryId = houseplantDto.CategoryId,
        };
    }

    public static HouseplantDto ToDto(this Houseplant houseplantEntity, HouseplantApiDbContext dbContext)
    {
        Category? category = dbContext.Categories.Find(houseplantEntity.CategoryId);

        return new HouseplantDto(houseplantEntity.Id, houseplantEntity.Name, houseplantEntity.Leaves, houseplantEntity.CategoryId, category!);
    }
}
