using Project.Core.Settings;
using RestSharp;

namespace Project.Core.API.Managers;

public class SessionManager(ApiSettings apiSettings) : ISessionManager
{
    private readonly ApiSettings apiSettings = apiSettings;

    public RestRequest RestRequest => new()
    {
        Timeout = TimeSpan.FromMilliseconds(apiSettings.Timeout)
    };

    public RestClient RestClient => new(apiSettings.BaseApiURL);
}
