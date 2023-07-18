using System.ComponentModel.DataAnnotations;

namespace FilmLand.Domain.Entities.Genres;

public class Genre : Auditable
{
    [MaxLength(50)]
    public string Name { get; set; } = String.Empty;
}
