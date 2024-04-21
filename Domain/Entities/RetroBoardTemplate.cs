using System.Text.Json.Serialization;

namespace Domain.Entities;

public class RetroBoardTemplate
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string BackgroundUrl { get; set; }
    [JsonIgnore]
    public User User { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public List<RetroBoardTemplateColumn> Columns { get; set; } = new();
}