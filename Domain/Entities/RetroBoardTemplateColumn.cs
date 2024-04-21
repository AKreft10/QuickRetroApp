using System.Text.Json.Serialization;

namespace Domain.Entities;

public class RetroBoardTemplateColumn
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public RetroBoardTemplate Template { get; set; }
}