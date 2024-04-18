using Application.Users.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection.Common;
using Web.Infrastructure;

namespace Web.Controllers;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(RegisterNewUser, "Register")
            .MapPost(Login, "Login");
    }

    public async Task<IResult> RegisterNewUser(ISender sender, CreateUserCommand createUserCommand)
    {
        var result = await sender.Send(createUserCommand);
        return Results.Text(result.ToString());
    }

    public async Task<Result<string>> Login(ISender sender, LoginUserQuery loginUserQuery)
    {
        var result = await sender.Send(loginUserQuery);
        return new Result<string>(success: true, message: null, result);
    }
}