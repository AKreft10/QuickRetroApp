namespace Domain.Entities;

public class RetroBoard
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<RetroBoardColumn> Columns { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public string BackgroundUrl { get; set; }
    public User CreatedBy { get; set; }
}