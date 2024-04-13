using Application.Users.Commands;
using MediatR;
using Web.Infrastructure;

namespace Web.Controllers;

public class UserController : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetSmth)
            .MapPost(CreateUser, "Test");
    }

    public int GetSmth(int cs)
    {
        return 43;
    }
    
    public Task<int> CreateUser(ISender sender, CreateUserCommand command)
    {
        return sender.Send(command);
    }
}