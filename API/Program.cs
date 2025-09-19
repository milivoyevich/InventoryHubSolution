using Microsoft.EntityFrameworkCore;
using InventoryHub.API.Data;    
using Microsoft.OpenApi.Models; // Add this for Swagger
using Swashbuckle.AspNetCore;   // Optional, but helps with extension methods

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
        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapControllers();
        app.Run();
    }
}
