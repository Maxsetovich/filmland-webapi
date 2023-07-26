using FilmLand.DataAccess.Interfaces.Genres;
using FilmLand.DataAccess.Utilities;
using FilmLand.Domain.Entities.Genres;
using FilmLand.Domain.Exceptions.Genres;
using FilmLand.Service.Common.Helpers;
using FilmLand.Service.Dtos.Genres;
using FilmLand.Service.Interfaces.Common;
using FilmLand.Service.Interfaces.Genres;
using FilmLand.Service.Services.Common;

namespace FilmLand.Service.Services.Genres;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _repository;
    private readonly IPaginator _paginator;

    public GenreService(IGenreRepository genreRepository,
        IPaginator paginator)
    {
        this._repository = genreRepository;
        this._paginator = paginator;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(GenreCreateDto dto)
    {
        Genre genre = new Genre()
        {
            Name = dto.Name,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };
        var result = await _repository.CreateAsync(genre);
        return result > 0;

    }

    public async Task<bool> DeleteAsync(long genreId)
    {
        var genre = await _repository.GetByIdAsync(genreId);
        if (genre is null) throw new GenreNotFoundException();

        var dbResult = await _repository.DeleteAsync(genreId);
        return dbResult > 0;
    }

    public async Task<IList<Genre>> GetAllAsync(PaginationParams @params)
    {
        var genres = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return genres;
    }

    public async Task<Genre> GetByIdAsync(long genreId)
    {
        var genre = await _repository.GetByIdAsync(genreId);
        if (genre is null) throw new GenreNotFoundException();
        else return genre;
    }

    public async Task<bool> UpdateAsync(long genreId, GenreUpdateDto dto)
    {
        var genre = await _repository.GetByIdAsync(genreId);
        if (genre is null) throw new GenreNotFoundException();

        // parse new items to genre
        genre.Name = dto.Name;

        genre.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(genreId, genre);
        return dbResult > 0;
    }
}
