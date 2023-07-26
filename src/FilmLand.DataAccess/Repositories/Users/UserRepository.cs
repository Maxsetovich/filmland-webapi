using Dapper;
using FilmLand.DataAccess.Interfaces.Users;
using FilmLand.DataAccess.Utilities;
using FilmLand.DataAccess.ViewModels.Users;
using FilmLand.Domain.Entities.Users;

namespace FilmLand.DataAccess.Repositories.Users;

public class UserRepository : BaseRepository, IUserRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT COUNT(*) FROM users";
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

    public async Task<int> CreateAsync(User entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.users(first_name, last_name, image_path, phone_number, phone_number_confirmed, password_hash, salt, identity_role, created_at, updated_at) " +
                "VALUES (@FirstName, @LastName, @ImagePath, @PhoneNumber, @PhoneNumberConfirmed, @PasswordHash, @Salt, @IdentityRole, @CreatedAt, @UpdatedAt);";
            return await _connection.ExecuteAsync(query, entity);
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
            string query = $"DELETE FROM users WHERE id = {id}";
            return await _connection.ExecuteAsync(query, new { Id = id });
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

    public async Task<User?> GetByPhoneAsync(string phone)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM users WHERE phone_number = @PhoneNumber";
            var data = await _connection.QuerySingleAsync<User>(query, new { PhoneNumber = phone });
            return data;
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

    public async Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM users ORDER BY id DESC " +
                $"OFFSET {@params.GetSkipCount} LIMIT {@params.PageSize};";
            var result = (await _connection.QueryAsync<UserViewModel>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<UserViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<UserViewModel?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<(int ItemsCount, IList<UserViewModel>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, User entity)
    {
        throw new NotImplementedException();
    }
}

