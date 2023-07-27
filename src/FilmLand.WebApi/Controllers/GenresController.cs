using FilmLand.DataAccess.Utilities;
using FilmLand.Service.Dtos.Genres;
using FilmLand.Service.Interfaces.Genres;
using FilmLand.Service.Validators.Dtos.Genre;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmLand.WebApi.Controllers;

[Route("api/genres")]
[ApiController]
public class GenresController : ControllerBase
{
    private readonly IGenreService _service;
    private readonly int maxPageSize = 30;

    public GenresController(IGenreService service)
    {
        this._service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("genreId")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(long genreId)
        => Ok(await _service.GetByIdAsync(genreId));

    [HttpGet("count")]
    [AllowAnonymous]
    public async Task<IActionResult> CountAsync()
    => Ok(await _service.CountAsync());

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] GenreCreateDto dto)
    {
        var createValidator = new GenreCreateValidator();
        var result = createValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpPut("{genreId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(long genreId, [FromForm] GenreUpdateDto dto)
    {
        var updateValidator = new GenreUpdateValidator();
        var validationResult = updateValidator.Validate(dto);
        if (validationResult.IsValid) return Ok(await _service.UpdateAsync(genreId, dto));
        else return BadRequest(validationResult.Errors);
    }

    [HttpDelete("{genreId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long genreId)
       => Ok(await _service.DeleteAsync(genreId));
}

