using FilmLand.DataAccess.Interfaces.Titles;
using FilmLand.DataAccess.Repositories.Titles;
using FilmLand.Service.Interfaces.Auth;
using FilmLand.Service.Interfaces.Common;
using FilmLand.Service.Interfaces.Companies;
using FilmLand.Service.Interfaces.Countries;
using FilmLand.Service.Interfaces.Genres;
using FilmLand.Service.Interfaces.Languages;
using FilmLand.Service.Interfaces.Movies;
using FilmLand.Service.Interfaces.Notifications;
using FilmLand.Service.Interfaces.Titles;
using FilmLand.Service.Services.Auth;
using FilmLand.Service.Services.Common;
using FilmLand.Service.Services.Companies;
using FilmLand.Service.Services.Countries;
using FilmLand.Service.Services.Genres;
using FilmLand.Service.Services.Languages;
using FilmLand.Service.Services.Movies;
using FilmLand.Service.Services.Notifications;
using FilmLand.Service.Services.Titles;

namespace FilmLand.WebApi.Configurations.Layers;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<ICompanyService, CompanyService>();
        builder.Services.AddScoped<IGenreService, GenreService>();
        builder.Services.AddScoped<ICountryService, CountryService>();
        builder.Services.AddScoped<ILanguageService, LanguageService>();
        builder.Services.AddScoped<ITitleService, TitleService>();
        builder.Services.AddScoped<IMovieService, MovieService>(); 
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IPaginator, Paginator>();
        builder.Services.AddSingleton<ISmsSender, SmsSender>();

    }
}
