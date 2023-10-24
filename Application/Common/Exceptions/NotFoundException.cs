#region

using System.Net;
using System.Runtime.Serialization;
using ATC.Domain.Exceptions;

#endregion

namespace Application.Common.Exceptions;
[Serializable]
public class NotFoundException : AppException
{
    public NotFoundException(string message) : base(message) { }
    public NotFoundException(string message, Exception innerException) : base(message, innerException) { }
    protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    public override int StatusCode => (int)HttpStatusCode.NotFound;
}
