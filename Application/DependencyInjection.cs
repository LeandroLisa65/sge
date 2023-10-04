#region

using Microsoft.AspNetCore.Builder;

#endregion

namespace Application;

public static class DependencyInjection
{
    private static readonly string ApiVersion = "/1";

    public static IApplicationBuilder UseCommonApplication(this IApplicationBuilder app)
    {
        app.UsePathBase(ApiVersion);
        app.UseRouting();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseCors("LocalPolicy");

        return app;
    }
}