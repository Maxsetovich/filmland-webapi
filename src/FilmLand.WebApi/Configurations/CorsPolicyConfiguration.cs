namespace FilmLand.WebApi.Configurations;

public static class CorsPolicyConfiguration
{
    public static void ConfigureCORSPolicy(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(option =>
        {
            option.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyMethod();
            });

            option.AddPolicy("OnlySite", builder =>
            {
                builder.WithOrigins("https://www.filmland.uz")
                    .AllowAnyHeader().AllowAnyMethod();
            });
        });
    }
}

