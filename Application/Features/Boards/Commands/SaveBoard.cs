using Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection.Common;

namespace Microsoft.Extensions.DependencyInjection.Boards.Commands;

public record SaveBoardCommand : IRequest<Result<string>>
{
    public List<string> Columns { get; init; }
    public string BacgroundUrl { get; init; }
}

public class SaveBoard : IRequestHandler<SaveBoardCommand, Result<string>>
{
    private readonly IApplicationDbContext _dbContext;

    public SaveBoard(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<Result<string>> Handle(SaveBoardCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}