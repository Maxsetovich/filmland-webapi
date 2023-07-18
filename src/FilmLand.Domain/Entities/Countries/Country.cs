using System.ComponentModel.DataAnnotations;

namespace FilmLand.Domain.Entities.Countries;

public class Country : Auditable
{
    [MaxLength(50)]
    public string Name { get; set; } = String.Empty;
}
