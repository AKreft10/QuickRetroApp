using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Common;
using Microsoft.IdentityModel.Tokens;

namespace Application.Users.Commands;

public record LoginUserQuery : IRequest<Result<string>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginUser : IRequestHandler<LoginUserQuery, Result<string>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IPasswordHasher<User> _passwordHasher;

    public LoginUser(IApplicationDbContext dbContext, IPasswordHasher<User> passwordHasher)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
    }
    
    public async Task<Result<string>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var user = _dbContext.Users.FirstOrDefault(z => z.Email == request.Email);

        if (user is null)
            return new Result<string>(false, "Invalid email or password", null);

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);

        if (result == PasswordVerificationResult.Failed)
            return new Result<string>(false, "Invalid email or password", null);
            

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("Nickname", user.Nickname),
            new Claim("Nationality", user.Nationality)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0ELuSWcqfaRKStMIZVV1z9KKf99hsT6p"));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(1);

        var token = new JwtSecurityToken("http://quickretro.net", "http://quickretro.net", claims, expires: expires,
            signingCredentials: cred);

        var tokenHandler = new JwtSecurityTokenHandler();

        user.LastLogin = DateTime.Now;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new Result<string>(true, "Welcome back (:", tokenHandler.WriteToken(token));
    }
}