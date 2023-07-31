using Dapper;
using FilmLand.DataAccess.Interfaces.Languages;
using FilmLand.DataAccess.Utilities;
using FilmLand.Domain.Entities.Languages;

namespace FilmLand.DataAccess.Repositories.Languages;

public class LanguageRepository : BaseRepository, ILanguageRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT COUNT(*) FROM languages";
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

    public async Task<int> CreateAsync(Language entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.languages(name, created_at, updated_at) " +
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
            string query = "DELETE FROM languages WHERE id=@Id";
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

    public async Task<IList<Language>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM languages ORDER BY id DESC " +
                $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize};";
            var result = (await _connection.QueryAsync<Language>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Language>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Language?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM languages WHERE id=@Id";
            var result = await _connection.QuerySingleAsync<Language>(query, new { Id = id });
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

    public async Task<int> UpdateAsync(long id, Language entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.languages " +
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
