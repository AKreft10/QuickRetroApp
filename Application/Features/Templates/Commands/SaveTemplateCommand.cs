using System.Security.Claims;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Common;

namespace Microsoft.Extensions.DependencyInjection.Features.Templates.Commands;

public record SaveTemplateCommand : IRequest<Result<string>>
{
    public string Name { get; set; }
    public List<string> Columns { get; init; }
    public string BacgroundUrl { get; init; }
}

public class SaveTemplateCommandHandler : IRequestHandler<SaveTemplateCommand, Result<string>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SaveTemplateCommandHandler(IApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Result<string>> Handle(SaveTemplateCommand request, CancellationToken cancellationToken)
    {
        var userContextId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        
        var userEntity = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userContextId, cancellationToken);
        
        if(userEntity is null)
            return new Result<string>(false, "User not found", null);
        
        var templateEntity = new RetroBoardTemplate()
        {
            Name = request.Name,
            BackgroundUrl = request.BacgroundUrl,
            Columns = request.Columns.Select(x => new RetroBoardTemplateColumn() { Name = x }).ToList(),
            User = userEntity
        };
        
        await _dbContext.RetroBoardTemplates.AddAsync(templateEntity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return new Result<string>(true, "Template has been successfully saved", templateEntity.Id.ToString());
    }
}