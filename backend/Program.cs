using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://172.21.52.106:4200") // Update this with your frontend IP
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("AllowAngular"); // Enable CORS

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

// Add this to serve a response for "/"
app.MapGet("/", () => "Hello, World from .NET Root!");

app.Run();
