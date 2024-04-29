using Application.Common.Interfaces;

namespace Microsoft.Extensions.DependencyInjection.Features.Retro.Commands;

public record MoveCardCommand : IRequest
{
    public string MoveTo { get; set; }
    public string CardId { get; set; }
}

public class MoveCardHandler : IRequestHandler<MoveCardCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public MoveCardHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Handle(MoveCardCommand request, CancellationToken cancellationToken)
    {
        var card = await _dbContext.RetroBoardColumnItems.FirstOrDefaultAsync(x => x.Id.ToString() == request.CardId, cancellationToken);
        var column = await _dbContext.RetroBoardColumns.FirstOrDefaultAsync(x => x.Id.ToString() == request.MoveTo, cancellationToken);
        
        card.ColumnId = column;
        
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}