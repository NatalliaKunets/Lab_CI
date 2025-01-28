using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Project.Core.API.Models
{
	public record UserProfile
	{
		public string? DisplayName { get; set; }
		public ExternalUrls? ExternalUrls { get; set; }
		public Followers? Followers { get; set; }
		public string? Href { get; set; }
		public string? Id { get; set; }
		public List<Image>? Images { get; set; }
		public string? Type { get; set; }
		public string? Uri { get; set; }
	}

	public record ExternalUrls
	{
        [JsonPropertyName("spotify")]
        public string? Spotify { get; set; }
	}

    public record Followers
    {
        [JsonPropertyName("href")]
        public string? Href { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }

    public record Image
	{
		public string? Url { get; set; }
		public int? Height { get; set; }
		public int? Width { get; set; }
	}
}
