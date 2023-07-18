using FilmLand.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FilmLand.Domain.Entities.Users;

public class User : Human
{
    [MaxLength(50)]
    public string Email { get; set; } = String.Empty;

    public string PasswordHash { get; set; } = String.Empty;

    public string Salt { get; set; } = String.Empty;

    public IdentityRole Role { get; set; }
}
