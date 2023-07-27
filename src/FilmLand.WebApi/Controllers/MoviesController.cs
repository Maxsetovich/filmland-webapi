using FilmLand.DataAccess.Utilities;
using FilmLand.Service.Dtos.Movies;
using FilmLand.Service.Interfaces.Movies;
using FilmLand.Service.Validators.Dtos.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmLand.WebApi.Controllers;

[Route("api/movies")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _service;
    private readonly int maxPageSize = 30;

    public MoviesController(IMovieService service)
    {
        this._service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("{movieId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(long movieId)
        => Ok(await _service.GetByIdAsync(movieId));

    [HttpGet("count")]
    [AllowAnonymous]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpPost]
    [DisableRequestSizeLimit]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] MovieCreateDto dto)
    {
        var createValidator = new MovieCreateValidator();
        var result = createValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpPut("{movieId}")]
    [Authorize(Roles = "Admin")]
    [DisableRequestSizeLimit]
    public async Task<IActionResult> UpdateAsync(long movieId, [FromForm] MovieUpdateDto dto)
    {
        var updateValidator = new MovieUpdateValidator();
        var validationResult = updateValidator.Validate(dto);
        if (validationResult.IsValid) return Ok(await _service.UpdateAsync(movieId, dto));
        else return BadRequest(validationResult.Errors);
    }

    [HttpDelete("{movieId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long movieId)
        => Ok(await _service.DeleteAsync(movieId));

    [HttpGet("search")]
    [AllowAnonymous]
    public async Task<IActionResult> SearchAsync(string search, [FromQuery] int page = 1)
        => Ok(await _service.SearchAsync(search, new PaginationParams(page, maxPageSize)));
}
