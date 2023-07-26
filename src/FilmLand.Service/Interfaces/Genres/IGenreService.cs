using FilmLand.DataAccess.Utilities;
using FilmLand.Domain.Entities.Genres;
using FilmLand.Service.Dtos.Genres;

namespace FilmLand.Service.Interfaces.Genres;

public interface IGenreService
{
    public Task<bool> CreateAsync(GenreCreateDto dto);

    public Task<bool> DeleteAsync(long genreId);

    public Task<long> CountAsync();

    public Task<IList<Genre>> GetAllAsync(PaginationParams @params);

    public Task<Genre> GetByIdAsync(long genreId);

    public Task<bool> UpdateAsync(long genreId, GenreUpdateDto dto);
}
