#region

using Application;
using Infrastructure;

#endregion

namespace UI;

internal static class Program
{
    private static void Main(string[] args)
    {
        //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        
        var builder = WebApplication.CreateBuilder(args);
        var builderLoaded = LoadDependencies(builder);
        Configure(builderLoaded);
    }

    private static WebApplicationBuilder LoadDependencies(WebApplicationBuilder builder)
    {
        builder.Services
            .AddInfrastructureServices()
            .AddApplicationServices()
            .AddPostgresDbContext()
            .AddUIDependencies();

        return builder;
    }

    private static void Configure(WebApplicationBuilder builder)
    {
        var app = builder.Build();

        app.UseCommonApplication();
        
        app.MapControllers();
        app.MapGet("/", () => "Welcome to running ASP.NET Core Minimal API on AWS Lambda");
        app.AddMiddlewares();

        app.Run();
    }
}