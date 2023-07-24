using FilmLand.DataAccess.Common.Interfaces;
using FilmLand.DataAccess.ViewModels.Users;
using FilmLand.Domain.Entities.Users;

namespace FilmLand.DataAccess.Interfaces.Users;

public interface IUserRepository : IRepository<User, UserViewModel>,
    IGetAll<UserViewModel>, ISearchable<UserViewModel>
{
    public Task<User?> GetByPhoneAsync(string phone);
}
