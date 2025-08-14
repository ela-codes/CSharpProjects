using GameStore.Dtos;

namespace GameStore.Endpoints;

public static class GamesEndpoints
{

    private static readonly List<GameDto> games = [
        new (1,"Street Fighter II","Fighting",19.99M,new DateOnly(1992, 7,15)),
        new (2,"Final Fantasy XIV","Roleplaying",59.99M,new DateOnly(2010, 9, 30)),
        new (3,"FIFA 23","Sports",69.99M,new DateOnly(2022, 9, 27))
    ];

    const string GetGameEndpointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();

        // GET /games
        group.MapGet("/", () => games);

        // GET /games/1
        group.MapGet("/{id}", (int id) =>
        {
            GameDto? game = games.Find(game => game.Id == id);
            return game is null ? Results.NotFound() : Results.Ok(game);
        }).WithName(GetGameEndpointName); // creates a referrable name for this route.

        // POST /games
        group.MapPost("/", (CreateGameDto createGame) =>
        {
            GameDto newGame = new GameDto(
                games.Count + 1,
                createGame.Name,
                createGame.Genre,
                createGame.Price,
                createGame.ReleaseDate
            );
            games.Add(newGame);
            return Results.CreatedAtRoute(GetGameEndpointName, new { id = newGame.Id }, newGame);
            // use route name we specified in GET /games/{id}
        });

        // PUT /games/1
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            int index = games.FindIndex(game => game.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }
            games[index] = new GameDto(index + 1, updatedGame.Name, updatedGame.Genre, updatedGame.Price, updatedGame.ReleaseDate);

            return Results.NoContent();
        });

        // DELETE /games/1
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);
            return Results.NoContent();
        });
        return group;
    }
}
