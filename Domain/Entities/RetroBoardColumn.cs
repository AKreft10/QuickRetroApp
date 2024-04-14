namespace Domain.Entities;

public class RetroBoardColumn
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<RetroBoardColumnItem> Items { get; set; } = new();
    public RetroBoard BoardId { get; set; }
}