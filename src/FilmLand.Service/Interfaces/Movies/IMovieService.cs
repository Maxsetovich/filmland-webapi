using FilmLand.DataAccess.Utilities;
using FilmLand.DataAccess.ViewModels.Movies;
using FilmLand.Domain.Entities.Movies;
using FilmLand.Service.Dtos.Movies;

namespace FilmLand.Service.Interfaces.Movies;

public interface IMovieService
{
    public Task<bool> CreateAsync(MovieCreateDto dto);

    public Task<bool> DeleteAsync(long movieId);

    public Task<long> CountAsync();

    public Task<IList<MovieViewModel>> GetAllAsync(PaginationParams @params);

    public Task<Movie> GetByIdAsync(long movieId);

    public Task<bool> UpdateAsync(long movieId, MovieUpdateDto dto);

    public Task<IList<MovieViewModel>> SearchAsync(string search, PaginationParams @params);
}
