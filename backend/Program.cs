using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://0.0.0.0:4200") // Allow Angular frontend
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("AllowAngular"); // Enable CORS

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
