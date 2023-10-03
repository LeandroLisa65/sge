using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp1;

public static class DependencyInjection
{
    public static IServiceCollection AddBatch(this IServiceCollection services)
    {
        services
            .AddPostgresDbContext();
        return services;
    }
}