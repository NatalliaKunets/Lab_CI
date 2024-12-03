using Project.Core.API.Managers;
using Project.Core.API.Models;
using ReportPortal.Client.Abstractions.Responses;
using RestSharp;
using System.Text;

namespace Project.Core.API.Services;

public class AuthenticationService(ISessionManager sessionManager)
{
    private readonly ISessionManager sessionManager = sessionManager;
    private string? token;
    private readonly LoginRequest loginRequest = new("565f0ed63e9543f9a58ba381ad9a43b2", "52c3d9d84d8542fda77fcd31bdff445a");

    public RestClient GetAuthorizedClient()
    {
        var client = sessionManager.RestClient;
        client.AddDefaultHeader("Authorization", $"Bearer {GetToken()}");
        return client;
    }

    public string GetToken()
    {
        if(!string.IsNullOrEmpty(token))
        {
            return token;
        }

        var loginResponse = Login();

        if (loginResponse?.Data == null)
        {
            throw new InvalidOperationException("Login failed: Unable to get a Token.");
        }

        token = loginResponse.Data.AccessToken;
        if (string.IsNullOrEmpty(token))
        {
            throw new InvalidOperationException("Login failed: Invalid Token");
        }

        return token;
    }

    public RestResponse<LoginResponse> Login()
    {
        var client = sessionManager.RestClient;
        var request = sessionManager.RestRequest;
        
        request.Method = Method.Post;
        request.Resource = "https://accounts.spotify.com/api/token";
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

        request.AddParameter("grant_type", "client_credentials");
        request.AddParameter("client_id", loginRequest.ClientId);
        request.AddParameter("client_secret", loginRequest.ClientSecret);

        var response = client.Execute<LoginResponse>(request);
        return response;
    }

    //  One-time execution script for obtaining the Refresh Token
    private RestResponse GetRefreshToken()
    {
        //get authorizationCode:
        //https://accounts.spotify.com/authorize?client_id=565f0ed63e9543f9a58ba381ad9a43b2&response_type=code&redirect_uri=http://localhost:3000&scope=playlist-modify-public%20playlist-modify-private%20user-top-read%20user-read-playback-state
        string authorizationCode = "AQD5ih0rSG3wMDkxyQuWxaCop-0qEqz5q51tJqMG3XoiTeE9UVgmetVWipgNFqM8fnGs0OpfAEJKnJcPUAnkbAz0PbRiJjXt3weNTylJEAOuZtg5kbidbNIfz7AN1UHaQAiAeuw0WvZ3ZGEAJqPt12vtqoGNiQEMYyWij7RDDt_Z1hoZjq0w7IRpymS0RyeF_kq9pgYrg1XCH40mqBsmyumh35CUhtX4tQz3HeZ8CzqnK7UfBdzUXbOeP3L9744jbo3c_WjWiMHwhmZaWlYx1CsW4A";

        var client = sessionManager.RestClient;
        var request = sessionManager.RestRequest;

        request.Method = Method.Post;
        request.Resource = "https://accounts.spotify.com/api/token";


        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        string credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{loginRequest.ClientId}:{loginRequest.ClientSecret}"));
        request.AddHeader("Authorization", $"Basic {credentials}");

        request.AddParameter("grant_type", "authorization_code");
        request.AddParameter("code", authorizationCode);
        request.AddParameter("redirect_uri", "http://localhost:3000");

        var response = client.Execute(request);

        return response;
    }

    public string GetUserAuthorizedToken_UsingRefreshToken()
    {
        //string refreshToken = "AQA8Le-9ZM3tXhpAJqCIN71rDQmTflFYklouKB4zztiKxZ3fvIhcDcuyxNF18PKxAfKD_hpFWZHvItoRMBbQQ9SyM7cTt8ZQFtO-cOYPSS9kp0rV3NLN34US5QHkxdI1lo0";
        string? refreshToken = Environment.GetEnvironmentVariable("SPOTIFY_API_REFRESH_TOKEN");

        var client = sessionManager.RestClient;
        var request = sessionManager.RestRequest;

        request.Method = Method.Post;
        request.Resource = "https://accounts.spotify.com/api/token";

        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

        string credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{loginRequest.ClientId}:{loginRequest.ClientSecret}"));
        request.AddHeader("Authorization", $"Basic {credentials}");

        request.AddParameter("grant_type", "refresh_token");
        request.AddParameter("refresh_token", refreshToken);

        var response = client.Execute<LoginResponse>(request);
        if (response.Data == null || string.IsNullOrEmpty(response.Data.AccessToken))
        {
            throw new InvalidOperationException("Failed to refresh the access token.");
        }

        return response.Data.AccessToken;
    }

    public RestClient GetUserAuthorizedClient()
    {
        var client = sessionManager.RestClient;
        client.AddDefaultHeader("Authorization", $"Bearer {GetUserAuthorizedToken_UsingRefreshToken()}");
        return client;
    }
}
