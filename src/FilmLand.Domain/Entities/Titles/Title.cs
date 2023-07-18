using System.ComponentModel.DataAnnotations;

namespace FilmLand.Domain.Entities.Titles;

public class Title : Auditable
{
    [MaxLength(50)]
    public string Name { get; set; } = String.Empty;
}
