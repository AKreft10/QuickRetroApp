using Application.Users.Commands;
using MediatR;
using Web.Infrastructure;

namespace Web.Controllers;

public class UserController : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetSomehing, "GetSomething")
            .MapPost(AddSomething, "AddSomething")
            .MapPut(UpdateSomething, "UpdateSomething")
            .MapDelete(DeleteSomething, "DeleteSomething");
    }

    public int GetSomehing(ISender sender)
    {
        var rnd = new Random();
        return rnd.Next(1, 10000);
    }

    public async Task<IResult> AddSomething(ISender sender, int something)
    {
        return Results.Text($"$Udalo sie! {something}");
    }
    
    public async Task<IResult> UpdateSomething(ISender sender, int id)
    {
        return Results.NoContent();
    }

    public async Task<IResult> DeleteSomething(ISender sender, int id)
    {
        return Results.NoContent();
    }
}