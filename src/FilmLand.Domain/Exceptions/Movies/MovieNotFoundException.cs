namespace FilmLand.Domain.Exceptions.Movies;

public class MovieNotFoundException :NotFoundException
{
    public MovieNotFoundException()
    {
        this.TitleMessage = "Movie not found!";
    }
}
