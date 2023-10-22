using Application.Common.Persistance;
using Application.Common.Persistance.Repositories;
using Infrastructure.Common.Helpers;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPostgresDbContext(this IServiceCollection services)
    {
        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(opt => {
            var strConn = AwsCredentialsHelper.GetRdsCnnString().Result;
            opt.UseNpgsql(strConn, optionsBuilder => {
                optionsBuilder.MigrationsHistoryTable("__EFMigrationsHistory", "dbo");
                optionsBuilder.CommandTimeout(60 * 10); // Set higher timeout (10 min) due to default is only 30 secs.
            });
        });

        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IAuditableRepository<>), typeof(AuditableRepository<>));
        services.AddScoped(typeof(IEntityBaseRepository<>),typeof(EntityBaseRepository<>));
        
        return services;
    }
}