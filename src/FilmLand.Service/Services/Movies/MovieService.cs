using FilmLand.DataAccess.Interfaces.Movies;
using FilmLand.DataAccess.Utilities;
using FilmLand.DataAccess.ViewModels.Movies;
using FilmLand.Domain.Entities.Movies;
using FilmLand.Domain.Exceptions.Files;
using FilmLand.Domain.Exceptions.Movies;
using FilmLand.Service.Common.Helpers;
using FilmLand.Service.Dtos.Movies;
using FilmLand.Service.Interfaces.Common;
using FilmLand.Service.Interfaces.Movies;

namespace FilmLand.Service.Services.Movies;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _repository;
    private readonly IFileService _fileService;
    private readonly IPaginator _paginator;

    public MovieService(IMovieRepository movieRepository,
        IFileService fileService,
        IPaginator paginator)
    {
        this._repository = movieRepository;
        this._fileService = fileService;
        this._paginator = paginator;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(MovieCreateDto dto)
    {
        string imagepath = await _fileService.UploadImageAsync(dto.Image);
        string moviepath = await _fileService.UploadMovieAsync(dto.Movie);
        string trailerpath = await _fileService.UploadTrailerAsync(dto.Trailer);

        Movie movie = new Movie()
        {
            GenreId = dto.GenreId,
            TitleId = dto.TitleId,
            CompanyId = dto.CompanyId,
            LanguageId = dto.LanguageId,
            CountryId = dto.CountryId,
            Name = dto.Name,
            MoviePath = moviepath,
            ImagePath = imagepath,
            TrailerPath = trailerpath,
            Description = dto.Description,
            Rating = dto.Rating,
            ReleaseYear = dto.ReleaseYear,
            Duration = dto.Duration,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };
        var result = await _repository.CreateAsync(movie);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long movieId)
    {
        var movie = await _repository.GetByIdAsync(movieId);
        if (movie is null) throw new MovieNotFoundException();

        var resultImage = await _fileService.DeleteImageAsync(movie.ImagePath);
        if (resultImage == false) throw new ImageNotFoundException();

        var resultMovie = await _fileService.DeleteMovieAsync(movie.MoviePath);
        if (resultMovie == false) throw new MovieNotFoundException();

        var resultTrailer = await _fileService.DeleteTrailerAsync(movie.TrailerPath);
        if (resultTrailer == false) throw new TrailerNotFoundException();

        var dbResult = await _repository.DeleteAsync(movieId);
        return dbResult > 0;
    }

    public async Task<IList<MovieViewModel>> GetAllAsync(PaginationParams @params)
    {
        var movies = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return movies;
    }

    public async Task<Movie> GetByIdAsync(long movieId)
    {
        var movie = await _repository.GetByIdAsync(movieId);
        if (movie is null) throw new MovieNotFoundException();
        else return movie;
    }

    public async Task<IList<MovieViewModel>> SearchAsync(string search, PaginationParams @params)
    {
        var movies = await _repository.SearchAsync(search, @params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return movies.Item2.ToList();
    }

    public async Task<bool> UpdateAsync(long movieId, MovieUpdateDto dto)
    {
        var movie = await _repository.GetByIdAsync(movieId);
        if (movie is null) throw new MovieNotFoundException();

        // parse new items to movie
        movie.GenreId = dto.GenreId;
        movie.TitleId = dto.TitleId;
        movie.CompanyId = dto.CompanyId;
        movie.LanguageId = dto.LanguageId;
        movie.CountryId = dto.CountryId;
        movie.Name = dto.Name;

        if (dto.Movie is not null)
        {
            // delete old movie
            var deleteResult = await _fileService.DeleteMovieAsync(movie.MoviePath);
            if (deleteResult is false) throw new MovieNotFoundException();

            // upload new image
            string newMoviePath = await _fileService.UploadMovieAsync(dto.Movie);

            // parse new path to movie
            movie.MoviePath = newMoviePath;
        }

        if (dto.Image is not null)
        {
            // delete old image
            var deleteResult = await _fileService.DeleteImageAsync(movie.ImagePath);
            if (deleteResult is false) throw new ImageNotFoundException();

            // upload new image
            string newImagePath = await _fileService.UploadImageAsync(dto.Image);

            // parse new path to image
            movie.ImagePath = newImagePath;
        }

        if (dto.Trailer is not null)
        {
            // delete old trailer
            var deleteResult = await _fileService.DeleteTrailerAsync(movie.TrailerPath);
            if (deleteResult is false) throw new TrailerNotFoundException();

            // upload new trailer
            string newTrailerPath = await _fileService.UploadTrailerAsync(dto.Trailer);

            // parse new path to trailer
            movie.TrailerPath = newTrailerPath;
        }

        movie.Description = dto.Description;
        movie.Rating = dto.Rating;
        movie.ReleaseYear = dto.ReleaseYear;
        movie.Duration = dto.Duration;
        movie.UpdatedAt = TimeHelper.GetDateTime();


        var dbResult = await _repository.UpdateAsync(movieId, movie);
        return dbResult > 0;
    }
}
