using System.Net;

namespace FilmLand.Domain.Exceptions;

public class BadRequestException : Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;
    
    public string TitleMessage { get; protected set; } = String.Empty;
}
