namespace Microsoft.Extensions.DependencyInjection.Models;

public class MoveCardDto : CardOperationsBase
{
    public string CardId { get; set; }
    public string MoveTo { get; set; }
}