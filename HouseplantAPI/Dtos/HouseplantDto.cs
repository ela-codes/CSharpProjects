using System;
using System.ComponentModel.DataAnnotations;
using HouseplantAPI.Entities;

namespace HouseplantAPI.Dtos;

public record class HouseplantDto(
    [Required] int Id,
    [Required] string Name,
    [Required] [Range(1,50)] int Leaves,
    [Required] int CategoryId,
    Category Category
);
