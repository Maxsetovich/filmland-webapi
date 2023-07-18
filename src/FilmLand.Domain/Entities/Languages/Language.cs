using System.ComponentModel.DataAnnotations;

namespace FilmLand.Domain.Entities.Languages;

public class Language : Auditable
{
    [MaxLength(50)]
    public string Name { get; set; } = String.Empty;
}
