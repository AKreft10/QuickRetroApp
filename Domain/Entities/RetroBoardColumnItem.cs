using System.Text.Json.Serialization;

namespace Domain.Entities;

public class RetroBoardColumnItem
{
    public Guid Id { get; set; }
    public string TextContent { get; set; }
    public string CreatedBy { get; set; }
    [JsonIgnore]
    public RetroBoardColumn ColumnId { get; set; }
}