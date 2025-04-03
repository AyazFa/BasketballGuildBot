using System.IO;
using BasketBot.Interfaces;
using BasketBot.Providers;
using BasketBot.Services;
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
        
        builder.Services.AddTransient<IChatMembersFileInterface, ChatMembersFileProvider>();
        builder.Services.AddTransient<IPersonService, PersonService>();
        builder.Services.AddTransient<IPlayersFileInterface, PlayersFileProvider>();
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy =>
                {
                    policy.WithOrigins("http://localhost:4200");
                });
        });
        
        builder.Services.AddControllers();
        builder.Services.Configure<AppIdentitySettings>(
            builder.Configuration.GetSection("AppIdentitySettings"));        

        // NLog: Setup NLog for Dependency injection
        builder.Logging.ClearProviders();
        builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
        builder.Host.UseNLog();        
        
        // Add services to the container.
        Bot.GetBotClientAsync();
        
        builder.Services.AddControllers().AddNewtonsoftJson();
        builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true)
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddEnvironmentVariables()
            .AddCommandLine(args ?? new string[] { })
            .Build();        

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        
        app.UseHttpsRedirection();
        
        app.UseHttpsRedirection();  

        app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());        
        
        app.MapControllers();
        
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");        

        app.Run();
    }
}