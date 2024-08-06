using System.IO;
using BasketBotApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;

namespace BasketBotApi;

public static class Program
{
    public static void Main(string[] args)
    {
        var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
        logger.Debug("init main");
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy =>
                {
                    policy.WithOrigins("http://localhost:4200");
                });
        });
        
        builder.Services.AddControllers();

        // NLog: Setup NLog for Dependency injection
        builder.Logging.ClearProviders();
        builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
        builder.Host.UseNLog();        
        
        // Add services to the container.
        Bot.GetBotClientAsync();
        
        builder.Services.AddControllers().AddNewtonsoftJson();
        builder.Configuration.AddJsonFile($"appsettings.development.json", true)
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddEnvironmentVariables()
            .AddCommandLine(args ?? new string[] { })
            .Build();        

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        
        app.UseHttpsRedirection();
        
        app.UseCors();
        
        app.MapControllers();
        
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");        

        app.Run();
    }
}