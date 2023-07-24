using System.ComponentModel.DataAnnotations;

namespace FilmLand.Domain.Entities.Movies;

public class Movie : Auditable
{
    public long GenreId { get; set; }

    public long TitleId { get; set; }

    public long CompanyId { get; set; }

    public long LanguageId { get; set; }

    public long CountryId { get; set; }

    [MaxLength(50)]
    public string Name { get; set; } = String.Empty;

    public string MoviePath { get; set; } = String.Empty;

    public string ImagePath { get; set; } = String.Empty;

    public string TrailerPath { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    public float Rating { get; set; }

    public int ReleaseYear { get; set; }

    [MaxLength(5)]
    public string Duration { get; set; } = String.Empty;

}
