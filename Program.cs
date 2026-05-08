using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(config.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDataService, DataService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

app.MapGet("/api/data", async (AppDbContext db, IDataService dataService) =>
{
    var users = await db.Users.ToListAsync();
    
    var formatted = await dataService.GetFormattedUsersAsync(users);
    
    return Results.Json(new
    {
        appVersion = config["Version"],
        appName = config["AppName"],
        users = formatted
    });
});

app.MapGet("/api/config", (IConfiguration config) =>
{
    return Results.Json(new
    {
        appName = config["AppName"],
        version = config["Version"],
        maxItems = config.GetValue<int>("MaxItems")
    });
});

app.Run();