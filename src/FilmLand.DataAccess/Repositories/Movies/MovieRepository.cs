using Dapper;
using FilmLand.DataAccess.Interfaces.Movies;
using FilmLand.DataAccess.Utilities;
using FilmLand.DataAccess.ViewModels.Movies;
using FilmLand.Domain.Entities.Movies;

namespace FilmLand.DataAccess.Repositories.Movies;

public class MovieRepository : BaseRepository, IMovieRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT COUNT(*) FROM movies";
            var result = await _connection.QuerySingleAsync<long>(query);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        };
    }

    public async Task<int> CreateAsync(Movie entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.movies(genre_id, title_id, company_id, language_id, country_id, name, movie_path, image_path, trailer_path, description, rating, release_year, duration, created_at, updated_at) " +
                            "VALUES(@GenreId, @TitleId, @CompanyId, @LanguageId, @CountryId, @Name, @MoviePath, @ImagePath, @TrailerPath, @Description, @Rating, @ReleaseYear, @Duration, @CreatedAt, @UpdatedAt);";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM movies WHERE id=@Id";
            var result = await _connection.ExecuteAsync(query, new { Id = id });
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<MovieViewModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM movie_view ORDER BY id DESC " +
                $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize};";
            var result = (await _connection.QueryAsync<MovieViewModel>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<MovieViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Movie?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM movies WHERE id=@Id";
            var result = await _connection.QuerySingleAsync<Movie>(query, new { Id = id });
            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<(int ItemsCount, IList<MovieViewModel>)> SearchAsync(string search, PaginationParams @params)
    {
        //throw new NotImplementedException();
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM movie_view WHERE name ILIKE @search ORDER BY id DESC " +
                $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";
            var result = (await _connection.QueryAsync<MovieViewModel>(query, new { search = "%" + search + "%" })).ToList();
            return (result.Count, result);
        }
        catch
        {
            return (0, new List<MovieViewModel>());
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, Movie entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.movies " +
                $"SET genre_id=@GenreId, title_id=@TitleId, company_id=@CompanyId, language_id=@LanguageId, country_id=@CountryId, name=@Name, movie_path=@MoviePath, image_path=@ImagePath, trailer_path=@TrailerPath, description=@Description, rating=@Rating, release_year=@ReleaseYear, duration=@Duration, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                $"WHERE id={id}";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
