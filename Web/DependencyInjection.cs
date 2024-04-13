namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();


        services.AddHttpContextAccessor();

        services.AddRazorPages();

        // Customise default API behaviour

        services.AddEndpointsApiExplorer();

        services.AddOpenApiDocument((configure, sp) => { configure.Title = "QuickRetro API"; });

        return services;
    }
}