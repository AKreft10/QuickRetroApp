using Application.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    [HttpPost("CreateUser")]
    public async Task<int> CreateUser(ISender sender, CreateUserCommand command)
    {
        return await sender.Send(command);
    }
}