using RestSharp;

namespace Project.Core.API.Managers;

public interface ISessionManager
{
    RestRequest RestRequest { get; }
    RestClient RestClient { get; }
}
