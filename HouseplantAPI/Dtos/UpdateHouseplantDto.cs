using System;
using System.ComponentModel.DataAnnotations;

namespace HouseplantAPI.Dtos;

public record class UpdateHouseplantDto
(
    [Required] string Name,
    [Required] [Range(1,50)] int Leaves,
    [Required] int CategoryId
);
