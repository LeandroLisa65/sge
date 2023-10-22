using Infrastructure.Middlewares;

namespace UI;

public static class DependencyInjection
{
    private static readonly string ApiVersion = "/1";
    public static IServiceCollection AddUIDependencies(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
    
    public static IApplicationBuilder UseCommonApplication(this IApplicationBuilder app)
    {
        app.UsePathBase(ApiVersion);
        app.UseRouting();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        //app.UseAuthorization();
        app.UseCors("LocalPolicy");

        return app;
    }
    
    public static IApplicationBuilder AddMiddlewares(this IApplicationBuilder app) {
        app.UseMiddleware<ErrorHandlerMiddleware>();
        
        return app;
    }
}