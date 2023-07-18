namespace FilmLand.Domain.Exceptions.Titles;

public class TitleNotFoundException : NotFoundException
{
    public TitleNotFoundException()
    {
        this.TitleMessage = "Title not found!";
    }
}
