using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection.Features.Retro.Commands;
using Microsoft.Extensions.DependencyInjection.Models;

namespace Microsoft.Extensions.DependencyInjection.Hubs;

public class RetroBoardHub : Hub
{
    private readonly ISender _sender;

    public RetroBoardHub(ISender sender)
    {
        _sender = sender;
    }
    
    public override async Task OnConnectedAsync()
    {
        await Clients.Caller.SendAsync("UserConnected");
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
        await base.OnDisconnectedAsync(exception);
    }

    public async Task AddUserToGroup(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }
    
    public async Task AddCard(AddCardDto card)
    {
        var cardId = await _sender.Send(new AddCardCommand()
        {
            ConnectionId = Context.ConnectionId,
            CardContent = card.Content,
            ColumnId = card.ColumnId
        });
        
        await Clients.Group(card.BoardId).SendAsync("CardAdded", card.ColumnId, card.Content, cardId);
    }
    
    public async Task MoveCard(MoveCardDto move)
    {
        await _sender.Send(new MoveCardCommand()
        {
            CardId = move.CardId,
            MoveTo = move.MoveTo
        });
        
        await Clients.Group(move.BoardId).SendAsync("CardMoved", move.CardId, move.MoveTo);
    }
    
    public async Task AddUserConnection(string userId)
    {
        Console.WriteLine($"User {userId} connected");
    }
}