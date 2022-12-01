using Server.Data;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

namespace Server;

public class Program
{
    public static void Main(string[] args)
    {
#warning Программист, перед первой сборкой измени строку подключения и отправь миграцию на БД!

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddScoped<Repos.IEntryRepository, Repos.EntryRepository>();

        builder.Services.AddDbContext<EntryDbContext>(options =>
        {
            options.UseLazyLoadingProxies().UseSqlServer("Data Source=127.0.0.1,1433;Initial Catalog=EntryDatabase;User ID=sa;Password=Passlogin1;TrustServerCertificate=True;App=EntityFramework");
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

