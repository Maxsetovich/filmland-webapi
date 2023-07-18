using System.ComponentModel.DataAnnotations;

namespace FilmLand.Domain.Entities.Companies;

public class Company : Auditable
{
    [MaxLength(50)]
    public string Name { get; set; } = String.Empty;

    public string ImagePath { get; set; } = String.Empty;
}
