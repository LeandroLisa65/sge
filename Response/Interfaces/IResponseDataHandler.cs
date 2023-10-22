#region

using System.Net;
using FluentValidation.Results;

#endregion

namespace Response.Interfaces;

public interface IResponseDataHandler
{
    ResponseData<T> Ok<T>(T result);
    ResponseData<T> Ok<T>();
    ResponseData<T> Created<T>(T result);
    ResponseData<T> Validation<T>(ValidationResult validationResult);
    ResponseData<string> Error(Exception exception);
    HttpStatusCode GetHttpStatusCode(Exception exception);
}