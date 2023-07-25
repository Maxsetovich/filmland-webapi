using FilmLand.Service.Interfaces.Auth;
using FilmLand.Service.Interfaces.Common;
using FilmLand.Service.Interfaces.Companies;
using FilmLand.Service.Interfaces.Notifications;
using FilmLand.Service.Services.Auth;
using FilmLand.Service.Services.Common;
using FilmLand.Service.Services.Companies;
using FilmLand.Service.Services.Notifications;

namespace FilmLand.WebApi.Configurations.Layers;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<ICompanyService, CompanyService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IPaginator, Paginator>();
        builder.Services.AddSingleton<ISmsSender, SmsSender>();

    }
}
