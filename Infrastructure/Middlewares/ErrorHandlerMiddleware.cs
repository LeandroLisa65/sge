#region

using System.Net;
using ATC.Application.Services;
using ATC.Domain.Exceptions;
using Infrastructure.Common;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

#endregion

namespace ATC.Infrastructure.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(
        RequestDelegate next
    )
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, ICloudWatchLogger cloudWatchLogger)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            await HandleExceptionAsync(context, error);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        switch (exception)
        {
            case BadRequestException e:
                response.StatusCode = e.StatusCode;
                break;
            case NotFoundException e:
                response.StatusCode = e.StatusCode;
                break;
            default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        DefaultContractResolver contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        };

        var error = ResponseDataHandler.Error(exception);
        var result = JsonConvert.SerializeObject(error, new JsonSerializerSettings
        {
            ContractResolver = contractResolver
        });

        await response.WriteAsync(result);
    }
}