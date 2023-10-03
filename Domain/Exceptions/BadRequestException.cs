#region

using System.Net;
using System.Runtime.Serialization;

#endregion

namespace ATC.Domain.Exceptions;

[Serializable]
public class BadRequestException : AppException
{
    public BadRequestException(string message) : base(message) { }
    public BadRequestException(string message, Exception innerException) : base(message, innerException) { }
    protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    public override int StatusCode => (int)HttpStatusCode.BadRequest;
}
