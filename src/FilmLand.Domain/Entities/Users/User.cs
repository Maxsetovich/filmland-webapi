﻿using FilmLand.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FilmLand.Domain.Entities.Users;

public class User : Human
{
    [MaxLength(13)]
    public string PhoneNumber { get; set; } = String.Empty;
    public bool PhoneNumberConfirmed { get; set; }

    public string PasswordHash { get; set; } = String.Empty;

    public string Salt { get; set; } = String.Empty;

    public IdentityRole IdentityRole { get; set; }
}
