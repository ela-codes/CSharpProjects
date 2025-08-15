using System.ComponentModel.DataAnnotations;

namespace GameStore.Dtos;

public record class CreateGameDto(
    [Required][StringLength(50)] string Name,
    int GenreId,
    [Required][Range(1, 100)] decimal Price,
    DateOnly ReleaseDate
    );
