using NUnit.Framework;
using Project.Core.API.Models;
using Project.Core.Logging;
using RestSharp;
using System.Net;

namespace Project.Tests.API;

[TestFixture]
public class EndpointsFunctionality : BaseAPITest
{
    [TestCase("0TnOYISbd1XYRBk9myaseg")]
    public void Verify_GetArtistResponse_WithValidArtistId(string artistId)
    {
        Logger.Information("Starting Test Verify Get Artist Response With Valid Artist Id");

        var client = authenticationService.GetAuthorizedClient();

        var request = new RestRequest($"https://api.spotify.com/v1/artists/{artistId}", Method.Get);

        var response = client.Execute<ArtistResponse>(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Failed to Get the specified Artist.");
        Assert.That(response.Data?.Id, Is.EqualTo(artistId), $"The Artist's Id does not match {artistId}");

        Logger.Information("Test Verify Get Artist Response With Valid Artist Id executed.");
    }

    [Test]
    public void Verify_GetPlayerPlaybackStateResponse()
    {
        Logger.Information("Starting Test Verify Get Player Playback State Response");

        var client = authenticationService.GetUserAuthorizedClient();

        var request = new RestRequest("https://api.spotify.com/v1/me/player", Method.Get);

        var response = client.Execute<PlaybackResponse>(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK).Or.EqualTo(HttpStatusCode.NoContent), "Failed to Get Player Playback State.");
        if(response.StatusCode == HttpStatusCode.OK)
        {
            Assert.That(response.Data?.Item?.Name, Is.Not.Null, $"Playing track's name should not be null when the response is OK.");
        }

        Logger.Information("Test Verify Get Player Playback State Response executed.");
    }

    [TestCase("remaster", "track")]
    public void Verify_SearchForSongResponse(string query, string type)
    {
        Logger.Information("Starting Test Verify Search For a Song Response");

        var client = authenticationService.GetAuthorizedClient();

        var request = new RestRequest("https://api.spotify.com/v1/search", Method.Get);
        request.AddParameter("q", query);
        request.AddParameter("type", type);

        var response = client.Execute<SearchResponse>(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Failed to Search For a Song.");
        Assert.That(response.Data?.Tracks?.Items[0].Id, Is.Not.Null, "Search Results should not be empty");

        Logger.Information("Test Verify Search For a Song Response executed.");
    }
}
