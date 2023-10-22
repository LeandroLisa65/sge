#region

using Application.Common.Persistance.Repositories;
using Application.Mappers;
using Application.Services;
using Application.Services.Interfaces;
using Application.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));
        services.AddScoped(typeof(IAuditableService<,>),typeof(AuditableService<,>));
        services.AddScoped(typeof(IRequestMapperService<,>), typeof(RequestMapperService<,>));
        
        services.AddMappingProfiles();
        services.AddValidators();
        
        return services;
    }

    public static IServiceCollection AddMappingProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(x => x.AddProfile<CompanyMappingProfile>());

        return services;
    }

    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CompanyValidator>(ServiceLifetime.Scoped);
        
        return services;
    }
}