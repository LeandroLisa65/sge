#region

using System.Net;
using FluentValidation.Results;
using Response.Interfaces;

#endregion

namespace Response;

public class ResponseDataHandler : IResponseDataHandler
{
    public ResponseData<T> Ok<T>(T result)
    {
        return new ResponseData<T>
        {
            Data = result,
            StatusCode = HttpStatusCode.OK,
            Success = true
        };
    }

    public ResponseData<T> Ok<T>()
    {
        return new ResponseData<T>
        {
            StatusCode = HttpStatusCode.OK,
            Success = true
        };
    }

    public ResponseData<T> Created<T>(T result)
    {
        return new ResponseData<T>
        {
            Data = result,
            StatusCode = HttpStatusCode.Created,
            Success = true
        };
    }

    public ResponseData<T> Validation<T>(ValidationResult validationResult)
    {
        var errors = new List<string>();

        foreach (var failure in validationResult.Errors)
            errors.Add("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);

        return new ResponseData<T>
        {
            Message = errors,
            StatusCode = HttpStatusCode.BadRequest,
            Success = false
        };
    }

    public ResponseData<string> Error(Exception exception) 
    {
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

    public virtual HttpStatusCode GetHttpStatusCode(Exception exception)
    {
        switch (exception)
        {
            default:
                return HttpStatusCode.InternalServerError;
        }
    }
}

