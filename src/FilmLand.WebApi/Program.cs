using FilmLand.DataAccess.Interfaces.Companies;
using FilmLand.DataAccess.Interfaces.Users;
using FilmLand.DataAccess.Repositories.Companies;
using FilmLand.DataAccess.Repositories.Users;
using FilmLand.Service.Interfaces.Auth;
using FilmLand.Service.Interfaces.Common;
using FilmLand.Service.Interfaces.Companies;
using FilmLand.Service.Interfaces.Notifications;
using FilmLand.Service.Services.Auth;
using FilmLand.Service.Services.Common;
using FilmLand.Service.Services.Companies;
using FilmLand.Service.Services.Notifications;
using FilmLand.WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();

//-> DI containers, IoC containers
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddSingleton<ISmsSender, SmsSender>();
builder.ConfigureJwtAuth();
//->

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
