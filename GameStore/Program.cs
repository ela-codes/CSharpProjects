using GameStore.Data;
using GameStore.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// get db configuration from appsettings.json (accessible by builder. Configuration)

var connString = builder.Configuration.GetConnectionString("GameStore"); // not ideal

builder.Services.AddSqlite<GameStoreContext>(connString); // registered as a Scoped service

var app = builder.Build();
app.MapGamesEndpoints();
app.MapGenresEndpoints();
await app.MigrateDbAsync();
app.Run();
