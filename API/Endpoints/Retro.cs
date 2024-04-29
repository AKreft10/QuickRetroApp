using Domain.Entities;
using Microsoft.Extensions.DependencyInjection.Common;
using Microsoft.Extensions.DependencyInjection.Features.Retro.Commands;
using Microsoft.Extensions.DependencyInjection.Features.Retro.Queries;

namespace Web.Controllers;

public class Retro : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(GetBoard, "GetBoard")
            .MapPost(Start, "Start");
    }

    public async Task<Result<string>> Start(ISender sender, StartRetroCommand command)
    {
        return await sender.Send(command);
    }
    
    public async Task<Result<RetroBoard>> GetBoard(ISender sender, GetBoardQuery query)
    {
        return await sender.Send(query);
    }
}