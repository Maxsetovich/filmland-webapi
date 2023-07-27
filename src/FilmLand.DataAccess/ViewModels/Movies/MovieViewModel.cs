namespace FilmLand.DataAccess.ViewModels.Movies;

public class MovieViewModel
{
    public string GenreName { get; set; } = String.Empty;

    public string TitleName { get; set; } = String.Empty;

    public string CompanyName { get; set; } = String.Empty;

    public string LanguageName { get; set; } = String.Empty;

    public string CountryName { get; set; } = String.Empty;

    public string Name { get; set; } = String.Empty;

    public string MoviePath { get; set; } = String.Empty;

    public string ImagePath { get; set; } = String.Empty;

    public string TrailerPath { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    public float Rating { get; set; }

    public int ReleaseYear { get; set; }

    public string Duration { get; set; } = String.Empty;

}
