//This file starts your entire API, sets up the database connection, 
//registers the controllers, enables Swagger, and starts the server.
// Here the information from appsettings.json file is used to create the database connection


using carelink_api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Registrate the database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

//Helps using swagger for using API in nettleser
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddControllers();

//Builts the webpage
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers(); //Connects the URLs (routes) to your controllers, e.g. /api/refugee."

app.Run();
