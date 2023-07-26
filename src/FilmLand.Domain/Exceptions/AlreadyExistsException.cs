using System.Net;

namespace FilmLand.Domain.Exceptions;

public class AlreadyExistsException : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

    public override string TitleMessage { get; protected set; } = String.Empty;
}
