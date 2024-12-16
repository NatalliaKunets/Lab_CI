using NUnit.Framework;
using Project.Core.API.Models;
using Project.Core.Logging;
using RestSharp;
using System.Net;

namespace Project.Tests.API;

[TestFixture]
public class PlaylistEndpointsFunctionality : BaseAPITest
{
    [TestCase("New API test Playlist"), Category("API")]
    public void Verify_CreatePlaylistResponse(string playlistName)
    {
        Logger.Information("Starting Test Verify Create Playlist Response");

        var client = authenticationService.GetUserAuthorizedClient();

        var request = new RestRequest($"/users/{userId}/playlists", Method.Post);
        request.AddJsonBody(new { name = playlistName });

        var response = client.Execute<PlaylistResponse>(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created), "Failed to Create a new Playlist.");
        Assert.That(response.Data?.Name, Is.EqualTo(playlistName), $"The Playlist's name does not match {playlistName}");

        Logger.Information("Playlist is created");

        #region PostConditions: Unfolow the created playlist to delete it from user library
        var delRequest = new RestRequest($"/playlists/{response.Data?.Id}/followers", Method.Delete);
        var delResponse = client.Execute(delRequest);
        if (delResponse.StatusCode != HttpStatusCode.OK)
        {
            Logger.Error("PostConditions: Unable to unfolow the created playlist to delete it from user library.");
        }
        #endregion

        Logger.Information("Test Verify Create Playlist Response executed.");
    }

    [TestCase("TestPlaylist", "spotify:track:1301WleyT98MSxVHPZCA6M"), Category("API")]
    public void Verify_AddItemToPlaylistResponse(string playlistName, string trackUri)
    {
        Logger.Information("Starting Test Add Item To Playlist Response");

        var client = authenticationService.GetUserAuthorizedClient();

        #region Preconditions: Create a playlist
        var playlistRequest = new RestRequest($"/users/{userId}/playlists", Method.Post);
        playlistRequest.AddJsonBody(new { name = playlistName });

        var playlistResponse = client.Execute<PlaylistResponse>(playlistRequest);

        if (playlistResponse.StatusCode != HttpStatusCode.Created)
        {
            Logger.Error("PreConditions: Unable to create a playlist.");
            Assert.Fail("Unable to create a playlist");
            return;
        }

        var playlistId = playlistResponse.Data?.Id;
        if (string.IsNullOrEmpty(playlistId))
        {
            Logger.Error("PreConditions: Unable to get the new playlist's Id.");
            Assert.Fail("Unable to get the new playlist's Id");
            return;
        }

        Logger.Information($"Playlist {playlistName} created.");
        #endregion

        var trackRequest = new RestRequest($"/playlists/{playlistId}/tracks", Method.Post);
        trackRequest.AddJsonBody(new { uris = new[] { trackUri } });
        var trackResponse = client.Execute(trackRequest);

        Assert.That(trackResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created), "Failed to Add a track to the Playlist.");

        Logger.Information($"Track was added to Playlist {playlistName}.");

        #region PostConditions: Unfolow the created playlist to delete it from user library
        var delRequest = new RestRequest($"/playlists/{playlistId}/followers", Method.Delete);
        var delResponse = client.Execute(delRequest);
        if (delResponse.StatusCode != HttpStatusCode.OK)
        {
            Logger.Error("PostConditions: Unable to unfolow the created playlist to delete it from user library.");
        }
        #endregion

        Logger.Information("Test Verify Add Item To Playlist Response executed.");
    }

    [TestCase("TestPlaylist", "spotify:track:1301WleyT98MSxVHPZCA6M"), Category("API")]
    public void Verify_RemoveItemFromPlaylistResponse(string playlistName, string trackUri)
    {
        Logger.Information("Starting Test Remove Item From Playlist Response");

        var client = authenticationService.GetUserAuthorizedClient();

        #region Preconditions: Create a playlist
        var playlistRequest = new RestRequest($"/users/{userId}/playlists", Method.Post);
        playlistRequest.AddJsonBody(new { name = playlistName });

        var playlistResponse = client.Execute<PlaylistResponse>(playlistRequest);

        if (playlistResponse.StatusCode != HttpStatusCode.Created)
        {
            Logger.Error("PreConditions: Unable to create a playlist.");
            Assert.Fail("Unable to create a playlist");
            return;
        }

        var playlistId = playlistResponse.Data?.Id;
        if (string.IsNullOrEmpty(playlistId))
        {
            Logger.Error("PreConditions: Unable to get the new playlist's Id.");
            Assert.Fail("Unable to get the new playlist's Id");
            return;
        }

        Logger.Information($"Playlist {playlistName} created.");
        #endregion

        #region Preconditions: Add a track to the playlist

        var trackRequest = new RestRequest($"/playlists/{playlistId}/tracks", Method.Post);
        trackRequest.AddJsonBody(new { uris = new[] { trackUri } });
        var trackResponse = client.Execute(trackRequest);

        if (trackResponse.StatusCode != HttpStatusCode.Created)
        {
            Logger.Error("PreConditions: Unable to add a track to the playlist.");
            Assert.Fail("Unable to add a track to the playlist");
            return;
        }
        Logger.Information($"Track added to Playlist {playlistName}.");
        #endregion

        var trackRemoveRequest = new RestRequest($"/playlists/{playlistId}/tracks", Method.Delete);
        trackRemoveRequest.AddJsonBody(new 
            {
                tracks = new[]
                    {
                        new { uri = trackUri }
                    }
            });
        var trackRemoveResponse = client.Execute(trackRemoveRequest);

        Assert.That(trackRemoveResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Failed to Remove a track from the Playlist.");

        Logger.Information($"Track was removed from the Playlist {playlistName}.");


        #region PostConditions: Unfolow the created playlist to delete it from user library
        var delRequest = new RestRequest($"/playlists/{playlistId}/followers", Method.Delete);
        var delResponse = client.Execute(delRequest);
        if (delResponse.StatusCode != HttpStatusCode.OK)
        {
            Logger.Error("PostConditions: Unable to unfolow the created playlist to delete it from user library.");
        }
        #endregion

        Logger.Information("Test Verify Remove Item From the Playlist Response executed.");
    }
}
