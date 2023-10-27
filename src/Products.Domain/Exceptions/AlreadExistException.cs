using System.Net;

namespace Products.Domain.Exceptions;

public class AlreadExistException : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;
    public override string TitleMessage { get; protected set; } = String.Empty;
}
