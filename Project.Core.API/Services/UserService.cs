using Project.Core.API.Managers;
using Project.Core.API.Models;
using Project.Core.Logging;
using RestSharp;

namespace Project.Core.API.Services;

public class UserService : BaseService
{
	private readonly AuthenticationService _authenticationService;

	public UserService(ISessionManager sessionManager, AuthenticationService authenticationService)
		: base(sessionManager)
	{
		_authenticationService = authenticationService;
	}

	public UserProfile GetUserProfile(string userId)
	{
		Logger.Information($"Fetching user profile for User ID: {userId}");

		var client = _authenticationService.GetAuthorizedClient();
		var request = CreateRequest($"https://api.spotify.com/v1/users/{userId}", Method.Get);

		var response = client.Execute<UserProfile>(request);
		if (response.StatusCode != System.Net.HttpStatusCode.OK || response.Data == null)
		{
			Logger.Error($"Failed to fetch user profile. Status: {response.StatusCode}, Error: {response.ErrorMessage}");
			throw new InvalidOperationException("Failed to fetch user profile.");
		}

		return response.Data;
	}

	public TopItemResponse GetTopItems(string type, string timeRange = "medium_term", int limit = 20, int offset = 0)
	{
		Logger.Information($"Fetching top {type} items with time range: {timeRange}, limit: {limit}, offset: {offset}");

		if (type != "artists" && type != "tracks")
		{
			throw new ArgumentException("Invalid type. Valid values are 'artists' or 'tracks'.", nameof(type));
		}

		var client = _authenticationService.GetUserAuthorizedClient();

        var requestUrl = $"https://api.spotify.com/v1/me/top/{type}?time_range={timeRange}&limit={limit}&offset={offset}";
		var request = CreateRequest(requestUrl, Method.Get);

		var response = client.Execute<TopItemResponse>(request);
		if (response.StatusCode != System.Net.HttpStatusCode.OK || response.Data == null)
		{
			Logger.Error($"Failed to fetch top items. Status: {response.StatusCode}, Error: {response.ErrorMessage}");
			throw new InvalidOperationException("Failed to fetch top items.");
		}

		return response.Data;
	}
}
