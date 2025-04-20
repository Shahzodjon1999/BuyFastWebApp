using BuyFastApi.Infrastructure;
using BuyFastApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

//add Configration Service for all services
builder.Services.AddApplication(builder.Configuration);

// Enable Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Calls migration to create or update the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred while migrating the database: " + ex.Message);
        throw; // Optionally rethrow if you want the app to crash
    }
    
    if (!context.Users.Any())
    {
        var user = new User()
        {
            Email = "admin@admin.com",
            Username = "BuyFast1999",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("BuyFast1999"),
            Role = "Admin"
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();
    }
}

// Enable Swagger UI in development and production
app.UseSwagger();
app.UseSwaggerUI();

//Enable CORS 
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseStaticFiles(); 
// Optional: Use HTTPS Redirection
app.UseHttpsRedirection();

app.UseAuthentication(); // 👈 Add this before UseAuthorization

app.UseAuthorization();

app.MapControllers();

app.Run();
