using System.ComponentModel.DataAnnotations;

namespace GameStore.Dtos;

public record class GameDetailsDto(
    [Required] int Id,
    [Required][StringLength(50)] string Name,
    int GenreId,
    [Required][Range(1, 100)] decimal Price,
    DateOnly ReleaseDate
);
