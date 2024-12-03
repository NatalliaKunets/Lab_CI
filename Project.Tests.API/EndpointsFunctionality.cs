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
}
