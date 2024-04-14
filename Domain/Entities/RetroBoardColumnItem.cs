namespace Domain.Entities;

public class RetroBoardColumnItem
{
    public Guid Id { get; set; }
    public string TextContent { get; set; }
    public string CreatedBy { get; set; }
    public RetroBoardColumn ColumnId { get; set; }
}