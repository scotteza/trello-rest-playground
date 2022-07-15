using System.Text.Json.Serialization;

namespace TrelloRestPlayground.Api.Cards;

public class TrelloCard
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    [JsonPropertyName("desc")]
    public string? Description { get; set; }
}
