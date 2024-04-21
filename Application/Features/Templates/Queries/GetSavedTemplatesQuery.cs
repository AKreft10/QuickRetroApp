using System.Security.Claims;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Common;

namespace Microsoft.Extensions.DependencyInjection.Features.Templates.Queries;

public record GetSavedTemplatesQuery : IRequest<Result<List<RetroBoardTemplate>>>;

public class GetSavedTemplatesQueryHandler : IRequestHandler<GetSavedTemplatesQuery, Result<List<RetroBoardTemplate>>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetSavedTemplatesQueryHandler(IApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Result<List<RetroBoardTemplate>>> Handle(GetSavedTemplatesQuery request, CancellationToken cancellationToken)
    {
        var userContextId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        
        var userEntity = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userContextId, cancellationToken);
        
        if(userEntity is null)
            return new Result<List<RetroBoardTemplate>>(false, "User not found", null);
        
        var templates = await _dbContext.RetroBoardTemplates
            .Where(x => x.User.Id == userEntity.Id)
            .Include(x => x.Columns)
            .ToListAsync(cancellationToken);
        
        return new Result<List<RetroBoardTemplate>>(true, "Templates has been successfully fetched", templates);
    }
}
