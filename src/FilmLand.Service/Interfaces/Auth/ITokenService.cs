using FilmLand.Domain.Entities.Users;

namespace FilmLand.Service.Interfaces.Auth;

public interface ITokenService
{
    public Task<string> GenerateToken(User user);
}
