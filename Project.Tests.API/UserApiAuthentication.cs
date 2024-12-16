using NUnit.Framework;
using Project.Core.Logging;
using RestSharp;
using System.Net;

namespace Project.Tests.API;

[TestFixture]
public class UserApiAuthentication : BaseAPITest
{
    [Test, Category("API")]
    public void User_CanLogin_WithValidToken() {
        Logger.Information("Starting Test User Can Login With Valid Token");

        var client = authenticationService.GetAuthorizedClient();

        var request = new RestRequest($"/users/{userId}", Method.Get);

        var response = client.Execute(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Failed to Login With Valid Token.");

        Logger.Information("Test User Can Login With Valid Token executed.");
    }

    [TestCase("NotValidToken"), Category("API")]
    public void User_CannotLogin_WithInvalidToken(string token)
    {
        Logger.Information("Starting Test User Cannot Login With Invalid Token");

        var client = sessionManager.RestClient;
        client.AddDefaultHeader("Authorization", $"Bearer {token}");

        var request = new RestRequest($"/users/{userId}", Method.Get);

        var response = client.Execute(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized), "Login With Invalid Token did not behave as expected.");

        Logger.Information("Test User Cannot Login With Invalid Token executed.");
    }
}
