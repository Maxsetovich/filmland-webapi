namespace FilmLand.Domain.Exceptions.Countries;

public class CountryNotFoundException : NotFoundException
{
    public CountryNotFoundException()
    {
        this.TitleMessage = "Country not found!";
    }
}
