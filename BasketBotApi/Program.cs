using System.IO;
using BasketBotApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        Bot.GetBotClientAsync();

        builder.Services.AddControllers().AddNewtonsoftJson();
        builder.Configuration.AddJsonFile($"appsettings.development.json", true)
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddEnvironmentVariables()
            .AddCommandLine(args ?? new string[] { })
            .Build();        

        var app = builder.Build();

        app.UseDeveloperExceptionPage();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}