using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configure CORS for Angular frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://0.0.0.0:4200") // Use "localhost" instead of "0.0.0.0"
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

// ✅ Redirect `/` to `/api/hello`
app.MapGet("/", async (HttpContext context) =>
{
    context.Response.Redirect("/api/hello");
});

// Map API controllers
app.MapControllers();

// Run the application
app.Run();
