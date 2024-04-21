using Domain.Entities;
using Microsoft.Extensions.DependencyInjection.Common;
using Microsoft.Extensions.DependencyInjection.Features.Templates.Commands;
using Microsoft.Extensions.DependencyInjection.Features.Templates.Queries;

namespace Web.Controllers;

public class Templates : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(SaveTemplate, "SaveTemplate")
            .MapGet(GetSavedTemplates, "GetSavedTemplates");
    }
    
    public async Task<Result<string>> SaveTemplate(ISender sender, SaveTemplateCommand saveTemplateCommand)
    {
        return await sender.Send(saveTemplateCommand);
    }
    
    public async Task<Result<List<RetroBoardTemplate>>> GetSavedTemplates(ISender sender)
    {
        return await sender.Send(new GetSavedTemplatesQuery());
    }
}