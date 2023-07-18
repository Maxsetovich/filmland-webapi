using FilmLand.DataAccess.Interfaces.Genres;
using FilmLand.DataAccess.Repositories.Genres;
using FilmLand.Domain.Entities.Genres;
using FilmLand.Service.Dtos.Genres;
using Microsoft.AspNetCore.Mvc;

namespace FilmLand.WebApi.Controllers;

[Route("api/genres")]
[ApiController]
public class GenresController : ControllerBase
{
    //private readonly IWebHostEnvironment _env;
    //public GenresController(IWebHostEnvironment env)
    //{
    //    this._env = env;
    //}
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] GenreCreateDto dto)
    {
        //IGenreRepository genreRepository = new GenreRepository();
        return Ok();
    }
}

