using Microsoft.AspNetCore.Http;

namespace FilmLand.Service.Dtos.Companies;

public class CompanyCreateDto
{
    public string Name { get; set; } = String.Empty;

    public IFormFile Image { get; set; } = default!;

}
