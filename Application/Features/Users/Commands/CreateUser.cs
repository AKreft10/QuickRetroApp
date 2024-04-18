using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Users.Commands;

public record CreateUserCommand : IRequest<Guid>
{
    public string Email { get; set; }
    public string Nickname { get; set; }
    public string Password { get; set; }
    public string Nationality { get; set; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IPasswordHasher<User> _passwordHasher;

    public CreateUserCommandHandler(IApplicationDbContext dbContext, IPasswordHasher<User> passwordHasher)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
    }
    
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
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

        return userEntity.Id;
    }
}