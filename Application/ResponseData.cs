#region

using System.Net;
using Microsoft.AspNetCore.Http;

#endregion

namespace Application;

public record class ResponseData<T> : IResult
{
    public ResponseData()
    {
        Message = Enumerable.Empty<string>();
    }

    public bool Success { get; set; }
    public T? Data { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public IEnumerable<string> Message { get; set; }

    public async Task ExecuteAsync(HttpContext httpContext)
    {
        await Task.CompletedTask;
    }
}

