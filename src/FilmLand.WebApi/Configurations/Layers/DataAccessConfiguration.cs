using FilmLand.DataAccess.Interfaces.Companies;
using FilmLand.DataAccess.Interfaces.Countries;
using FilmLand.DataAccess.Interfaces.Genres;
using FilmLand.DataAccess.Interfaces.Languages;
using FilmLand.DataAccess.Interfaces.Movies;
using FilmLand.DataAccess.Interfaces.Titles;
using FilmLand.DataAccess.Interfaces.Users;
using FilmLand.DataAccess.Repositories.Companies;
using FilmLand.DataAccess.Repositories.Countries;
using FilmLand.DataAccess.Repositories.Genres;
using FilmLand.DataAccess.Repositories.Languages;
using FilmLand.DataAccess.Repositories.Movies;
using FilmLand.DataAccess.Repositories.Titles;
using FilmLand.DataAccess.Repositories.Users;

namespace FilmLand.WebApi.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
        builder.Services.AddScoped<IGenreRepository, GenreRepository>();
        builder.Services.AddScoped<ICountryRepository, CountryRepository>();
        builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
        builder.Services.AddScoped<ITitleRepository, TitleRepository>();
        builder.Services.AddScoped<IMovieRepository, MovieRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
    }
}
