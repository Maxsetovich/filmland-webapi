using Dapper;
using FilmLand.DataAccess.Interfaces.Titles;
using FilmLand.DataAccess.Utilities;
using FilmLand.Domain.Entities.Titles;

namespace FilmLand.DataAccess.Repositories.Titles;

public class TitleRepository : BaseRepository, ITitleRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT COUNT(*) FROM titles";
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

    public async Task<int> CreateAsync(Title entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.titles(name, created_at, updated_at) " +
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
            string query = "DELETE FROM titles WHERE id=@Id";
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

    public async Task<IList<Title>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM titles ORDER BY id DESC " +
                $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize};";
            var result = (await _connection.QueryAsync<Title>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Title>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Title?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM titles WHERE id=@Id";
            var result = await _connection.QuerySingleAsync<Title>(query, new { Id = id });
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

    public async Task<int> UpdateAsync(long id, Title entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.titles " +
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
