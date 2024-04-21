using System.Text;
using Azure.Identity;
using Microsoft.Extensions.DependencyInjection.Common;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        var authConfiguration = new AuthConfiguration();
        configuration.GetSection("Authentication").Bind(authConfiguration);
        
        services.AddSingleton(authConfiguration);
        services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = "Bearer";
            option.DefaultScheme = "Bearer";
            option.DefaultChallengeScheme = "Bearer";
        }).AddJwtBearer(config =>
        {
            config.RequireHttpsMetadata = false;
            config.SaveToken = true;
            config.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = authConfiguration.JwtIssuer,
                ValidAudience = authConfiguration.JwtIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authConfiguration.JwtKey)),
            };
        });
        
        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder => builder.WithOrigins("http://localhost:4200").WithOrigins("https://blue-dune-0e106bc03.5.azurestaticapps.net/")
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowAnyHeader());
        });
        
        services.AddDatabaseDeveloperPageExceptionFilter();


        services.AddHttpContextAccessor();

        services.AddRazorPages();

        services.AddEndpointsApiExplorer();

        services.AddOpenApiDocument((configure, sp) => { configure.Title = "QuickRetro API"; });

        return services;
    }
    
    public static IServiceCollection AddKeyVaultIfConfigured(this IServiceCollection services, ConfigurationManager configuration)
    {
        var config = configuration.GetSection("AzureKeyVaultConfig").Get<AzureKeyVaultConfig>();
        if (!string.IsNullOrWhiteSpace(config.VaultUri))
        {
            configuration.AddAzureKeyVault(
                new Uri(config.VaultUri),
                new DefaultAzureCredential());
        }

        return services;
    }
}