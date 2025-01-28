using System.Text.Json.Serialization;

namespace Project.Core.API.Models;

public record SearchResponse
{
    [JsonPropertyName("tracks")]
    public FoundTracks? Tracks { get; set; }
}

public record FoundTracks
{
    [JsonPropertyName("href")]
    public string? Href { get; set; }

    [JsonPropertyName("limit")]
    public int Limit { get; set; }

    [JsonPropertyName("next")]
    public string? Next { get; set; }

    [JsonPropertyName("offset")]
    public int Offset { get; set; }

    [JsonPropertyName("previous")]
    public string? Previous { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("items")]
    public List<TrackObject>? Items { get; set; }
}