using GameStore.Dtos;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string GetGameEndpointName = "GetGameById";

List<GameDto> games = new()
{
    new GameDto(1, "The Witcher 3: Wild Hunt", "RPG", 39.99m, new DateOnly(2015, 5, 19)),
    new GameDto(2, "Cyberpunk 2077", "Action RPG", 59.99m, new DateOnly(2020, 12, 10)),
    new GameDto(3, "Minecraft", "Sandbox", 26.95m, new DateOnly(2011, 11, 18)),
    new GameDto(4, "Among Us", "Party", 4.99m, new DateOnly(2018, 6, 15)),
    new GameDto(5, "Hades", "Roguelike", 24.99m, new DateOnly(2020, 9, 17))
};

//  GET /games
app.MapGet("/games", () => games);

//  GET /games/{id}
app.MapGet("/games/{id}", (int id) => 
{
    games.Find(game => game.Id == id);

    
})
.WithName(GetGameEndpointName);

// POST /games
app.MapPost("/games", (CreateGameDto newGame) =>
{
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
});

// PUT /games/{id}
app.MapPut("/games/{id}", (int id, UpdateGameDto updateGameDto) =>
{
    var gameIndex = games.FindIndex(game => game.Id == id);

    games[gameIndex] = new GameDto(
        id,
        updateGameDto.Name,
        updateGameDto.Genre,
        updateGameDto.Price,
        updateGameDto.ReleaseDate
    );

    return Results.NoContent();
});

// DELETE /games/{id}
app.MapDelete("/games/{id}", (int id) =>
{
    games.RemoveAll(game => game.Id == id);

    return Results.NoContent();
});

app.Run();
