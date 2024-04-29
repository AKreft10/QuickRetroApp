namespace Microsoft.Extensions.DependencyInjection.Models;

public class AddCardDto : CardOperationsBase
{
    public string ColumnId { get; set; }
    public string Content { get; set; }
}