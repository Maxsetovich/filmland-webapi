using FilmLand.DataAccess.Utilities;
using FilmLand.Service.Dtos.Languages;
using FilmLand.Service.Interfaces.Languages;
using FilmLand.Service.Validators.Dtos.Language;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmLand.WebApi.Controllers;

[Route("api/languages")]
[ApiController]
public class LanguagesController : ControllerBase
{
    private readonly ILanguageService _service;
    private readonly int maxPageSize = 30;

    public LanguagesController(ILanguageService service)
    {
        this._service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
       => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("languageId")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(long languageId)
        => Ok(await _service.GetByIdAsync(languageId));

    [HttpGet("count")]
    [AllowAnonymous]
    public async Task<IActionResult> CountAsync()
    => Ok(await _service.CountAsync());

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] LanguageCreateDto dto)
    {
        var createValidator = new LanguageCreateValidator();
        var result = createValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpPut("{languageId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(long languageId, [FromForm] LanguageUpdateDto dto)
    {
        var updateValidator = new LanguageUpdateValidator();
        var validationResult = updateValidator.Validate(dto);
        if (validationResult.IsValid) return Ok(await _service.UpdateAsync(languageId, dto));
        else return BadRequest(validationResult.Errors);
    }

    [HttpDelete("{languageId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long languageId)
       => Ok(await _service.DeleteAsync(languageId));
}
