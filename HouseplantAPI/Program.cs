using HouseplantAPI;
using HouseplantAPI.Endpoints;

// set up WebApplication with the DB connection
var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("HouseplantApiDb");
builder.Services.AddSqlite<HouseplantApiDbContext>(connString);

// build WebApplication and attach routes
var app = builder.Build();
app.MapHouseplantEndpoints();

app.Run();
