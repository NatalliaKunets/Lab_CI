using Project.Core.API.Managers;
using Project.Core.API.Services;
using Project.Core.Logging;
using Project.Core.Settings;

namespace Project.Tests.API;

public class BaseAPITest
{
    protected readonly ISessionManager sessionManager;
    protected readonly AuthenticationService authenticationService;
    protected readonly string userId;
    protected readonly UserService _userService;

    public BaseAPITest()
    {
        Logger.Information("Starting BaseAPITest");

        var apiSettings = ConfigurationManager.GetApiSettings();
        sessionManager = new SessionManager(apiSettings);
        authenticationService = new AuthenticationService(sessionManager);
        _userService = new UserService(sessionManager,authenticationService);
        userId = ConfigurationManager.GetUserCredentials().Username;
    }
}
