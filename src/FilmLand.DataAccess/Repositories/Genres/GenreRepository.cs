using Dapper;
using FilmLand.DataAccess.Interfaces.Genres;
using FilmLand.DataAccess.Utilities;
using FilmLand.Domain.Entities.Genres;

namespace FilmLand.DataAccess.Repositories.Genres;

public class GenreRepository : BaseRepository, IGenreRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT COUNT(*) FROM genres";
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
        }
    }

    public async Task<int> CreateAsync(Genre entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.genres(name, created_at, updated_at) " +
                "VALUES (@Name, @CreatedAt, @UpdatedAt);";
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
            string query = "DELETE FROM genres WHERE id=@Id";
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

    public async Task<IList<Genre>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM genres ORDER BY id DESC " +
                $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize};";
            var result = (await _connection.QueryAsync<Genre>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Genre>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Genre?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM genres WHERE id=@Id";
            var result = await _connection.QuerySingleAsync<Genre>(query, new { Id = id });
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

    public async Task<int> UpdateAsync(long id, Genre entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.genres " +
                $"SET name=@Name, created_at=@CreatedAt, updated_at=@UpdatedAt " +
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
