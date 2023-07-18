using Dapper;
using FilmLand.DataAccess.Interfaces.Companies;
using FilmLand.DataAccess.Utilities;
using FilmLand.Domain.Entities.Companies;

namespace FilmLand.DataAccess.Repositories.Companies;

public class CompanyRepository : BaseRepository, ICompanyRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT COUNT(*) FROM companies";
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

    public async Task<int> CreateAsync(Company entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.companies(name, image_path, created_at, updated_at) " +
                "VALUES (@Name, @ImagePath, @CreatedAt, @UpdatedAt);";
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
            string query = "DELETE FROM companies WHERE id=@Id";
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

    public async Task<IList<Company>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM companies ORDER BY id DESC " +
                $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize};";
            var result = (await _connection.QueryAsync<Company>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Company>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Company?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM companies WHERE id=@Id";
            var result = await _connection.QuerySingleAsync<Company>(query, new { Id = id });
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

    public async Task<int> UpdateAsync(long id, Company entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.companies " +
                $"SET name=@Name, image_path=@ImagePath, created_at=@CreatedAt, updated_at=@UpdatedAt " +
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
