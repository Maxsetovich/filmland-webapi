using FilmLand.DataAccess.Utilities;
using FilmLand.Service.Dtos.Countries;
using FilmLand.Service.Interfaces.Countries;
using FilmLand.Service.Validators.Dtos.Country;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmLand.WebApi.Controllers;

[Route("api/countries")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly ICountryService _service;
    private readonly int maxPageSize = 30;

    public CountriesController(ICountryService service)
    {
        this._service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
       => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("countryId")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(long countryId)
    => Ok(await _service.GetByIdAsync(countryId));

    [HttpGet("count")]
    [AllowAnonymous]
    public async Task<IActionResult> CountAsync()
    => Ok(await _service.CountAsync());

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] CountryCreateDto dto)
    {
        var createValidator = new CountryCreateValidator();
        var result = createValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpPut("{countryId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(long countryId, [FromForm] CountryUpdateDto dto)
    {
        var updateValidator = new CountryUpdateValidator();
        var validationResult = updateValidator.Validate(dto);
        if (validationResult.IsValid) return Ok(await _service.UpdateAsync(countryId, dto));
        else return BadRequest(validationResult.Errors);
    }

    [HttpDelete("{countryId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long countryId)
      => Ok(await _service.DeleteAsync(countryId));
}
