using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands;

public record CreateUserCommand : IRequest<Guid>
{
    public string Email { get; set; }
    public string Nickname { get; set; }
    public string PasswordHash { get; set; }
    public string Nationality { get; set; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateUserCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userEntity = new User()
        {
            Email = request.Email,
            Nickname = request.Nickname,
            PasswordHash = request.PasswordHash,
            Nationality = request.Nationality
        };

        _dbContext.Users.Add(userEntity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return userEntity.Id;
    }
}