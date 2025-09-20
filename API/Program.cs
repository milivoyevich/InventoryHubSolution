using InventoryHub.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models; // Add this for Swagger
using Swashbuckle.AspNetCore; // Optional, but helps with extension methods

namespace InventoryHub.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<InventoryDbContext>(options =>
            options.UseInMemoryDatabase("InventoryDb")
        );

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "InventoryHub API V1");
                c.RoutePrefix = string.Empty; // Swagger at root
            });
        }
        app.MapControllers();
        app.UseCors(policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
        app.Run();
    }
}
