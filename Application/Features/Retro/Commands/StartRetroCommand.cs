using System.Security.Claims;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Common;

namespace Microsoft.Extensions.DependencyInjection.Features.Retro.Commands;

public record StartRetroCommand : IRequest<Result<string>>
{
    public string Name { get; set; }
    public List<string> Columns { get; init; }
    public string BacgroundUrl { get; init; }
}

public class StartRetroCommandHandler : IRequestHandler<StartRetroCommand, Result<string>>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IApplicationDbContext _dbContext;

    public StartRetroCommandHandler(IHttpContextAccessor httpContextAccessor, IApplicationDbContext dbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _dbContext = dbContext;
    }

    public async Task<Result<string>> Handle(StartRetroCommand request, CancellationToken cancellationToken)
    {
        var userContextId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        
        var userEntity = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userContextId, cancellationToken);
        
        if(userEntity is null)
            return new Result<string>(false, "User not found", null);
        
        var templateEntity = new RetroBoard()
        {
            Name = request.Name,
            BackgroundUrl = request.BacgroundUrl,
            Columns = request.Columns.Select(x => new RetroBoardColumn() { Name = x }).ToList(),
            CreatedBy = userEntity
        };
        
        await _dbContext.RetroBoards.AddAsync(templateEntity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return new Result<string>(true, "Template has been successfully saved", templateEntity.Id.ToString());
    }
}