using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configure CORS to allow Angular frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://0.0.0.0:4200") // Use "localhost" instead of "0.0.0.0" for browser compatibility
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

// Add Controllers
builder.Services.AddControllers();

var app = builder.Build();

// Middleware Pipeline
app.UseRouting();
app.UseCors("AllowAngular");
app.UseAuthorization();

// Default route for base URL
app.MapGet("/", () => "Backend is running! 🚀");

// Map API controllers
app.MapControllers();

// Run the application
app.Run();
