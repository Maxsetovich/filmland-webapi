namespace FilmLand.Domain.Exceptions.Genres;

public class GenreNotFoundException : NotFoundException
{
    public GenreNotFoundException()
    {
        this.TitleMessage = "Genre not found!";
    }
}
