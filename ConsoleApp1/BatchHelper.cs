#region

using Microsoft.Extensions.DependencyInjection;

#endregion

namespace ConsoleApp1;

public static class BatchHelper
{
    public static async Task ConfigureContextAsync()
    {
        await Task.CompletedTask;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public static IServiceProvider ConfigureServices(this IServiceCollection services)
    {
        services
            .AddBatch();

        return services.BuildServiceProvider();
    }
}