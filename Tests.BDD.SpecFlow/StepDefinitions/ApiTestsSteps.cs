using Project.Core.Logging;
using Project.Core.API.Models;
using Project.Core.API.Services;
using RestSharp;
using System.Net;

namespace Project.Tests.BDD.StepDefinitions;

[Binding]
public class ApiTestsSteps(AuthenticationService authenticationService) : BaseBddApiTest(authenticationService)
{
    [Given("I have a valid API token for authentication")]
    public void GivenIHaveAValidAPITokenForAuthentication()
    {
        client = authenticationService.GetAuthorizedClient();
        Logger.Information("I have a valid API token for authentication executed.");
    }

    [When(@"I perform a GET request for Artist with id (.*)")]
    public void WhenIPerformAGETRequestForArtistWithId(string artistId)
    {
        var request = new RestRequest($"/artists/{artistId}", Method.Get);
        artistResponse = client?.Execute<ArtistResponse>(request);

        Logger.Information("I perform a GET request for Artist with id executed.");
    }

    [Then(@"Response status code should be (.*)")]
    public void ThenResponseStatusCodeShouldBe(int statusCode)
    {
        artistResponse.Should().NotBeNull("Response cannot be null.");

        artistResponse!.StatusCode.Should().Be((HttpStatusCode)statusCode, "Status Code should be 200 OK.");

        Logger.Information("Response status code should be executed.");
    }

    [Then(@"Response should contain artist details \((.*), (.*)\)")]
    public void ThenResponseShouldContainArtistDetailsXFUcqCigfRFXzUDrake(string artistId, string artistName)
    {
        artistResponse!.Data?.Id.Should().Be(artistId, $"Artist's Id should be {artistId}");
        artistResponse.Data?.Name.Should().Be(artistName, $"Artist's Name should be {artistName}");

        Logger.Information("Response should contain artist details executed.");
    }
}

