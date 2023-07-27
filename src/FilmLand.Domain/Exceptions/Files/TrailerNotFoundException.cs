namespace FilmLand.Domain.Exceptions.Files;

public class TrailerNotFoundException : NotFoundException
{
    public TrailerNotFoundException()
    {
        this.TitleMessage = "Trailer not found!";
    }
}
