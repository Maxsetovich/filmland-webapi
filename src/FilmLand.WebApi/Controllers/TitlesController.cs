using FilmLand.DataAccess.Utilities;
using FilmLand.Service.Dtos.Titles;
using FilmLand.Service.Interfaces.Titles;
using FilmLand.Service.Validators.Dtos.Title;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmLand.WebApi.Controllers;

[Route("api/titles")]
[ApiController]
public class TitlesController : ControllerBase
{
    private readonly ITitleService _service;
    private readonly int maxPageSize = 30;

    public TitlesController(ITitleService service)
    {
        this._service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("titleId")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(long titleId)
        => Ok(await _service.GetByIdAsync(titleId));

    [HttpGet("count")]
    [AllowAnonymous]
    public async Task<IActionResult> CountAsync()
    => Ok(await _service.CountAsync());

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] TitleCreateDto dto)
    {
        var createValidator = new TitleCreateValidator();
        var result = createValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpPut("{titleId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(long titleId, [FromForm] TitleUpdateDto dto)
    {
        var updateValidator = new TitleUpdateValidator();
        var validationResult = updateValidator.Validate(dto);
        if (validationResult.IsValid) return Ok(await _service.UpdateAsync(titleId, dto));
        else return BadRequest(validationResult.Errors);
    }

    [HttpDelete("{titleId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long titleId)
       => Ok(await _service.DeleteAsync(titleId));
}
