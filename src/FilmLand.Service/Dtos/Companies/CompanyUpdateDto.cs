using Microsoft.AspNetCore.Http;

namespace FilmLand.Service.Dtos.Companies;

public class CompanyUpdateDto
{
    public string Name { get; set; } = String.Empty;

    public IFormFile? Image { get; set; }
}
