#region

using Microsoft.AspNetCore.Http;

#endregion

namespace Response;

public class EndpointResult
{
    public IResult? GetEndpointResult<T>(ResponseData<T> result)
    {
        switch (result.StatusCode)
        {
            case System.Net.HttpStatusCode.OK:
                return Results.Ok(result);
            case System.Net.HttpStatusCode.Created:
                return Results.Created(string.Empty, result);
            case System.Net.HttpStatusCode.BadRequest:
                return Results.BadRequest(result);
            case System.Net.HttpStatusCode.NotFound:
                return Results.NotFound(result);
            default:
                return null;
        }
    }
}

