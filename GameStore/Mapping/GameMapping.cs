using System;
using GameStore.Dtos;
using GameStore.Entities;

namespace GameStore.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDto gameDto)
    {
        return new Game()
        {
            Name = gameDto.Name,
            GenreId = gameDto.GenreId,
            Price = gameDto.Price,
            ReleaseDate = gameDto.ReleaseDate
        };
    }

    public static GameSummaryDto ToGameSummaryDto(this Game gameEntity)
    {
        return new
            (
                gameEntity.Id,
                gameEntity.Name,
                gameEntity.Genre!.Name,
                gameEntity.Price,
                gameEntity.ReleaseDate
            );
    }

    public static GameDetailsDto ToGameDetailsDto(this Game gameEntity)
    {
        return new
            (
                gameEntity.Id,
                gameEntity.Name,
                gameEntity.GenreId,
                gameEntity.Price,
                gameEntity.ReleaseDate
            );
    }
    public static Game ToEntity(this UpdateGameDto gameDto, int id)
    {
        return new Game()
        {
            Id = id,
            Name = gameDto.Name,
            GenreId = gameDto.GenreId,
            Price = gameDto.Price,
            ReleaseDate = gameDto.ReleaseDate
        };
    }
}
