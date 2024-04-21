namespace Microsoft.Extensions.DependencyInjection.Common;

public class AuthConfiguration
{
    public string JwtKey { get; set; }
    public int JwtExpireDays { get; set; }
    public string JwtIssuer { get; set; }
}