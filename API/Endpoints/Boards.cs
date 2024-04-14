using Microsoft.Extensions.DependencyInjection.Boards.Commands;

namespace Web.Controllers;

public class Boards : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(Create, "Create");
    }

    public async Task<IResult> Create(ISender sender, CreateBoardCommand createBoardCommand)
    {
        var result = await sender.Send(createBoardCommand);

        return Results.Text(result.ToString());
    }
}