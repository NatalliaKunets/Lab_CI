using NUnit.Framework;
using Project.Core.Logging;
using RestSharp;
using System.Net;

namespace Project.Tests.API;

public class UserApiAuthentication : BaseAPITest
{
    [Test]
    public void User_CanLogin_WithValidToken() {
        Logger.Information("Starting Test User Can Login With Valid Token");

        var client = authenticationService.GetAuthorizedClient();

        var request = new RestRequest($"https://api.spotify.com/v1/users/{userId}", Method.Get);

        var response = client.Execute(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Failed to Login With Valid Token.");

        Logger.Information("Test User Can Login With Valid Token executed.");
    }
}
