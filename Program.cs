using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddScoped<Repos.IEntryRepository, Repos.EntryRepository>();

        builder.Services.AddDbContext<Server.Data.EntryDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration["Settings:DatabaseOptions:ConnectionString"]);
        });

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

