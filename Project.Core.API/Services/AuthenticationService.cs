using Project.Core.API.Managers;
using Project.Core.API.Models;
using RestSharp;

namespace Project.Core.API.Services;

public class AuthenticationService(ISessionManager sessionManager)
{
    private readonly ISessionManager sessionManager = sessionManager;
    private string? token;

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

        var loginRequest = new LoginRequest("565f0ed63e9543f9a58ba381ad9a43b2", "52c3d9d84d8542fda77fcd31bdff445a");
        var loginResponse = Login(loginRequest);

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

    public RestResponse<LoginResponse> Login(LoginRequest loginRequest)
    {
        var client = sessionManager.RestClient;
        var request = sessionManager.RestRequest;
        
        request.Method = Method.Post;
        request.Resource = "https://accounts.spotify.com/api/token";
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

        request.AddParameter("grant_type", "client_credentials");
        request.AddParameter("client_id", loginRequest.ClientId);
        request.AddParameter("client_secret", loginRequest.ClientSecret);
        request.AddParameter("scope", "user-read-private user-read-email");

        var response = client.Execute<LoginResponse>(request);
        return response;
    }

}
