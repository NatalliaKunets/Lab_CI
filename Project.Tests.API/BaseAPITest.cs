using Project.Core.API.Managers;
using Project.Core.API.Services;
using Project.Core.Logging;
using Project.Core.Settings;

namespace Project.Tests.API;

public class BaseAPITest
{
    protected readonly ISessionManager sessionManager;
    protected readonly AuthenticationService authenticationService;

    public BaseAPITest()
    {
        Logger.Information("Starting BaseAPITest");

        var apiSettings = ConfigurationManager.GetApiSettings();
        sessionManager = new SessionManager(apiSettings);
        authenticationService = new AuthenticationService(sessionManager);
    }
}
