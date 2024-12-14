using Project.Core.API.Models;

namespace Project.Core.API.Helpers
{
	public static class UserServiceHelper
	{
		public static string GetDisplayName(UserProfile profile)
		{
			return profile?.DisplayName ?? "Unknown";
		}

		public static string GetSpotifyUrl(UserProfile profile)
		{
			return profile?.ExternalUrls?.Spotify ?? "No Spotify URL available";
		}

		public static int GetFollowersCount(UserProfile profile)
		{
			return profile?.Followers?.Total ?? 0;
		}

		public static string? GetProfileImageUrl(UserProfile profile)
		{
			if (profile?.Images?.Count > 0)
			{
				return profile.Images[0].Url;
			}
			return "No image available";
		}
	}
}
