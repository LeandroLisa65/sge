#region

using System.Net;
using Microsoft.AspNetCore.Http;

#endregion

namespace Response.Interfaces;

public interface IResponseData<T> : IResult
{
    bool Success { get; set; }
    T? Data { get; set; }
    HttpStatusCode StatusCode { get; set; }
    IEnumerable<string> Message { get; set; }
    new Task ExecuteAsync(HttpContext httpContext);
}