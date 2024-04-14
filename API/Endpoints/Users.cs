using Application.Users.Commands;
using MediatR;
using Web.Infrastructure;

namespace Web.Controllers;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(RegisterNewUser, "Register");
    }

    public async Task<IResult> RegisterNewUser(ISender sender, CreateUserCommand createUserCommand)
    {
        var result = await sender.Send(createUserCommand);
        return Results.Text(result.ToString());
    }
}