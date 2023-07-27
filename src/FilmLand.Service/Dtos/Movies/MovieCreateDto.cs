using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FilmLand.Service.Dtos.Movies;

public class MovieCreateDto
{
    public long GenreId { get; set; }

    public long TitleId { get; set; }

    public long CompanyId { get; set; }

    public long LanguageId { get; set; }

    public long CountryId { get; set; }

    [MaxLength(50)]
    public string Name { get; set; } = String.Empty;

    public IFormFile Movie { get; set; } = default!;

    public IFormFile Image { get; set; } = default!;

    public IFormFile Trailer { get; set; } = default!;

    public string Description { get; set; } = String.Empty;

    public float Rating { get; set; }

    public int ReleaseYear { get; set; }

    [MaxLength(5)]
    public string Duration { get; set; } = String.Empty;
}
