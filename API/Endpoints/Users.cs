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

    public async Task<Result<string>> RegisterNewUser(ISender sender, CreateUserCommand createUserCommand)
    {
        return await sender.Send(createUserCommand);
    }

    public async Task<Result<string>> Login(ISender sender, LoginUserQuery loginUserQuery)
    {
        return await sender.Send(loginUserQuery);
    }
}