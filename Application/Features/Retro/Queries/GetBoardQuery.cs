using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection.Common;

namespace Microsoft.Extensions.DependencyInjection.Features.Retro.Queries;

public record GetBoardQuery : IRequest<Result<RetroBoard>>
{
    public string Id { get; set; }
}

public class GetBoardQueryHandler : IRequestHandler<GetBoardQuery, Result<RetroBoard>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetBoardQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Result<RetroBoard>> Handle(GetBoardQuery request, CancellationToken cancellationToken)
    {
        var table = await _dbContext.RetroBoards
            .Include(z => z.Columns)
            .ThenInclude(x => x.Items)
            .FirstOrDefaultAsync(x => x.Id.ToString() == request.Id, cancellationToken);
        
        if(table is null)
            return new Result<RetroBoard>(false, "Table not found", null);

        return new Result<RetroBoard>(true, "Table has been successfully found", table);
    }
}