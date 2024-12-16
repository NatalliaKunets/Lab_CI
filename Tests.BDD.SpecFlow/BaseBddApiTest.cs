using Project.Core.API.Models;
using Project.Core.API.Services;
using Project.Core.Logging;
using RestSharp;

namespace Project.Tests.BDD;

[Binding]
public class BaseBddApiTest
{
    protected AuthenticationService authenticationService;
    protected RestClient? client;
    protected RestResponse<ArtistResponse>? artistResponse;

    public BaseBddApiTest(AuthenticationService authenticationService)
    {
        this.authenticationService = authenticationService;

        Logger.Information("BaseBddApiTest constructor executed");
    }
}
