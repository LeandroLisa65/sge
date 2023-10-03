#region

using System.Net;
using Application;
using ATC.Domain.Exceptions;
using FluentValidation.Results;

#endregion

namespace ATC.Application.Services;

public static class ResponseDataHandler
{
    public static ResponseData<T> Ok<T>(T result)
    {
        return new ResponseData<T>
        {
            Data = result,
            StatusCode = System.Net.HttpStatusCode.OK,
            Success = true
        };
    }

    public static ResponseData<T> Ok<T>()
    {
        return new ResponseData<T>
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Success = true
        };
    }

    public static ResponseData<T> Created<T>(T result)
    {
        return new ResponseData<T>
        {
            Data = result,
            StatusCode = System.Net.HttpStatusCode.Created,
            Success = true
        };
    }

    public static ResponseData<T> Validation<T>(ValidationResult validationResult)
    {
        var errors = new List<string>();

        foreach (var failure in validationResult.Errors)
            errors.Add("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);

        return new ResponseData<T>
        {
            Message = errors,
            StatusCode = System.Net.HttpStatusCode.BadRequest,
            Success = false
        };
    }

    public static ResponseData<string> Error(Exception exception) {
        var errors = new List<string>();
        var ex = exception;
        errors.Add(ex.Message);

        while (ex.InnerException != null) {
            ex = ex.InnerException;
            errors.Add(ex.Message);
        }

        var statusCode = GetHttpStatusCode(exception);

        var response = new ResponseData<string> {
            Message = errors,
            StatusCode = statusCode,
            Success = false
        };

        return response;
    }

    private static HttpStatusCode GetHttpStatusCode(Exception exception)
    {
        switch (exception)
        {
            case BadRequestException e:
                return (HttpStatusCode)e.StatusCode;
            case NotFoundException e:
                return (HttpStatusCode)e.StatusCode;
            default:
                return HttpStatusCode.InternalServerError;
        }
    }
}

