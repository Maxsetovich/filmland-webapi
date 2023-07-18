namespace FilmLand.Domain.Exceptions.Languages;

public class LanguageNotFoundException : NotFoundException
{
    public LanguageNotFoundException()
    {
        this.TitleMessage = "Language not found!";
    }
}
