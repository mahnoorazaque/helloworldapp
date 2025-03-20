using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy
            .SetIsOriginAllowed(origin => true) // Allow any origin
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddControllers();
var app = builder.Build();

app.UseCors("AllowAngular"); // Apply CORS policy
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
