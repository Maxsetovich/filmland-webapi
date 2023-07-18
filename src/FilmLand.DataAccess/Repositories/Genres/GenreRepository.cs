using Dapper;
using FilmLand.DataAccess.Interfaces.Genres;
using FilmLand.DataAccess.Utilities;
using FilmLand.Domain.Entities.Genres;
using static Dapper.SqlMapper;

namespace FilmLand.DataAccess.Repositories.Genres;

public class GenreRepository : BaseRepository, IGenreRepository
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
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

    public Task<Genre?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Genre entity)
    {
        throw new NotImplementedException();
    }
}
