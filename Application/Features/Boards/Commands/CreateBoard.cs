using Application.Common.Interfaces;
using Domain.Entities;

namespace Microsoft.Extensions.DependencyInjection.Boards.Commands;


public record CreateBoardCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public Guid CreatedBy { get; set; }
}

public class CreateBoard : IRequestHandler<CreateBoardCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateBoard(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Guid> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
    {
        var createdBy = await _dbContext.Users.Where(z => z.Id == request.CreatedBy).FirstOrDefaultAsync(cancellationToken);

        if (createdBy is null)
            throw new Exception("User not found");

        var boardEntity = new RetroBoard()
        {
            CreatedAt = DateTime.Now,
            CreatedBy = createdBy,
            Name = request.Name,
        };

        await _dbContext.RetroBoards.AddAsync(boardEntity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return boardEntity.Id;
    }
}