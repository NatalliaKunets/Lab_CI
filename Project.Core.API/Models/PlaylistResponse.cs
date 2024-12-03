using System.Text.Json.Serialization;

namespace Project.Core.API.Models;

public record PlaylistResponse
{
    [JsonPropertyName("collaborative")]
    public bool Collaborative { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("external_urls")]
    public ExternalUrls? ExternalUrls { get; set; }

    [JsonPropertyName("followers")]
    public Followers? Followers { get; set; }

    [JsonPropertyName("href")]
    public string? Href { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("images")]
    public List<ImageObject>? Images { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("owner")]
    public Owner? Owner { get; set; }

    [JsonPropertyName("public")]
    public bool? Public { get; set; }

    [JsonPropertyName("snapshot_id")]
    public string? SnapshotId { get; set; }

    [JsonPropertyName("tracks")]
    public Tracks? Tracks { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("uri")]
    public string? Uri { get; set; }
}

public record Owner
{
    [JsonPropertyName("external_urls")]
    public ExternalUrls? ExternalUrls { get; set; }

    [JsonPropertyName("followers")]
    public Followers? Followers { get; set; }

    [JsonPropertyName("href")]
    public string? Href { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("uri")]
    public string? Uri { get; set; }

    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }
}

public record Tracks
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
    public List<PlaylistTrackObject>? Items { get; set; }
}

public class PlaylistTrackObject
{
    public string AddedAt { get; set; } 

    public AddedByUser AddedBy { get; set; } 

    public bool IsLocal { get; set; } 

    public TrackInfo Track { get; set; } 

    
    public class AddedByUser
    {
        public ExternalUrls ExternalUrls { get; set; } // Known external URLs for the user.
        public string Href { get; set; } // API endpoint for the user.
        public string Id { get; set; } // Spotify user ID.
        public string Type { get; set; } // Type of object, e.g., "user".
        public string Uri { get; set; } // Spotify URI for the user.
        public string DisplayName { get; set; } // User's display name.
    }

    public class TrackInfo
    {
        public Album Album { get; set; } // Album details for the track.
        public List<SimplifiedArtist> Artists { get; set; } // List of artists who performed the track.
        public List<string> AvailableMarkets { get; set; } // Markets where the track can be played.
        public int DiscNumber { get; set; } // Disc number of the album.
        public int DurationMs { get; set; } // Track length in milliseconds.
        public bool Explicit { get; set; } // Whether the track has explicit lyrics.
        public ExternalIds ExternalIds { get; set; } // Known external IDs for the track.
        public ExternalUrls ExternalUrls { get; set; } // Known external URLs for the track.
        public string Href { get; set; } // API endpoint providing full details of the track.
        public string Id { get; set; } // Spotify ID for the track.
        public bool? IsPlayable { get; set; } // Indicates if the track is playable in the market.
        public TrackLinkedFrom LinkedFrom { get; set; } // Details about the originally requested track.
        public Restrictions Restrictions { get; set; } // Content restrictions for the track.
        public string Name { get; set; } // Name of the track.
        public int Popularity { get; set; } // Popularity of the track.
        public string PreviewUrl { get; set; } // Link to a 30-second preview of the track.
        public int TrackNumber { get; set; } // Track number in the album.
        public string Type { get; set; } // Object type, e.g., "track".
        public string Uri { get; set; } // Spotify URI for the track.
        public bool IsLocal { get; set; } // Indicates if the track is from a local file.
    }

    // Helper classes for nested objects
    public class Album
    {
        public string Name { get; set; }
        public List<SimplifiedArtist> Artists { get; set; }
        public string Href { get; set; }
    }

    public class SimplifiedArtist
    {
        public string Name { get; set; }
        public string Href { get; set; }
    }

    public class ExternalUrls
    {
        public string Spotify { get; set; }
    }

    public class ExternalIds
    {
        public string Isrc { get; set; }
    }

    public class TrackLinkedFrom
    {
        public string Href { get; set; }
    }

    public class Restrictions
    {
        public string Reason { get; set; }
    }
}
