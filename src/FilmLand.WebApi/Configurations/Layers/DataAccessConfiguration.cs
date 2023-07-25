using FilmLand.DataAccess.Interfaces.Companies;
using FilmLand.DataAccess.Interfaces.Users;
using FilmLand.DataAccess.Repositories.Companies;
using FilmLand.DataAccess.Repositories.Users;

namespace FilmLand.WebApi.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
    }
}
