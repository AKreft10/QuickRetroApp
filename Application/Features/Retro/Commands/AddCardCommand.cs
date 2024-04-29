using Application.Common.Interfaces;
using Domain.Entities;

namespace Microsoft.Extensions.DependencyInjection.Features.Retro.Commands;

public record AddCardCommand : IRequest<string>
{
    public string ConnectionId { get; set; }
    public string CardContent { get; set; }
    public string ColumnId { get; set; }
}

public class AddCardCommandHandler : IRequestHandler<AddCardCommand, string>
{
    private readonly IApplicationDbContext _dbContext;

    public AddCardCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<string> Handle(AddCardCommand request, CancellationToken cancellationToken)
    {
        var column = await _dbContext.RetroBoardColumns.FirstOrDefaultAsync(x => x.Id.ToString() == request.ColumnId, cancellationToken);
        
        var cardEntity = new RetroBoardColumnItem()
        {
            TextContent = request.CardContent,
            ColumnId = column,
            CreatedBy = request.ConnectionId
        };
        
        await _dbContext.RetroBoardColumnItems.AddAsync(cardEntity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return cardEntity.Id.ToString();
    }
}