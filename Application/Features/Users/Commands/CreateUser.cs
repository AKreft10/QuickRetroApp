using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Common;

namespace Application.Users.Commands;

public record CreateUserCommand : IRequest<Result<string>>
{
    public string Email { get; set; }
    public string Nickname { get; set; }
    public string Password { get; set; }
    public string Nationality { get; set; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<string>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IPasswordHasher<User> _passwordHasher;

    public CreateUserCommandHandler(IApplicationDbContext dbContext, IPasswordHasher<User> passwordHasher)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
    }
    
    public async Task<Result<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (_dbContext.Users.Any(z => z.Email == request.Email))
        {
            return new Result<string>(false, "The user with the specified e-mail address already exists", null);
        }
        
        var userEntity = new User()
        {
            Email = request.Email,
            Nickname = request.Nickname,
            Nationality = request.Nationality
        };

        var passwordHash = _passwordHasher.HashPassword(userEntity, request.Password);

        userEntity.PasswordHash = passwordHash;

        await _dbContext.Users.AddAsync(userEntity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new Result<string>(true, "User has been successfully registered. You can now log in", userEntity.Id.ToString());
    }
}