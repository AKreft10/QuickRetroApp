namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder => builder.WithOrigins("http://localhost:4200").WithOrigins("https://blue-dune-0e106bc03.5.azurestaticapps.net/")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
        
        services.AddDatabaseDeveloperPageExceptionFilter();


        services.AddHttpContextAccessor();

        services.AddRazorPages();

        // Customise default API behaviour

        services.AddEndpointsApiExplorer();

        services.AddOpenApiDocument((configure, sp) => { configure.Title = "QuickRetro API"; });

        return services;
    }
}