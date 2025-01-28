using Project.Core.API.Managers;
using Project.Core.API.Models;
using RestSharp;
using System.Text;

namespace Project.Core.API.Services;

public class AuthenticationService(ISessionManager sessionManager)
{
    private readonly ISessionManager sessionManager = sessionManager;
    private string? token;
    private readonly LoginRequest loginRequest = new("676d45e8eab44f31978c1cc9ca3bb694", "80479642ff4042778b166e47fec69847");

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
    /*
    public RestResponse GetRefreshToken()
    {
        //get authorizationCode:
        //https://accounts.spotify.com/authorize?client_id=676d45e8eab44f31978c1cc9ca3bb694&response_type=code&redirect_uri=http://localhost:3000&scope=playlist-modify-public%20playlist-modify-private%20user-top-read%20user-read-playback-state
        string authorizationCode = "AQBghYARQmB7Uskxb8bqSNCMERAMIH3zrQXZ6j9S0Swf7fQn0Wie6nFkSu_nvesA-IQflYkBv0p6tMO1fyFmIbvSSFukBP25MLcPaW5RV6LDLILRmH9rWyOqjLd0q-MBzcEr4wiDshnLgp7KP1ROYH4wgBwIQXuPWZNmwoqW1qxTxZbPsbnkuvHk6msDFdxEFbAEVs9qEomP5dsNlPYRVpvpKvCR8NaYYcoaU7DSUWppr-wiOdT4Fu-b-vicaN_t4ax6RwgeMRvJ1_jaZTDHyLXtmg";

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

        //Content "{\"access_token\":\"BQCp-I4SI7NnWri27DlpYBe9LfXizPp9TN5qu9jfV-60dEphGjMv3JLoXn0czySmVddAToVSTN9PgXg-v-l1lQJ0E1UXam-R9Ppj3ByxDnsSAoVugCL1qa9xXipKAXaVF7K3E3b75aeIo_tBj0_XDNlP3PlnfL7wSjGoHj1bptdE5BlYBxVRGtGATj1JxhFmSpWKMzviyeBOKQRGo9rSe8NvUL6ha-o7LqQB4l3smVKCfShq1oS-bWP7XsFEitVip00_RYpmTRpqSosxSOgpFA\",\"token_type\":\"Bearer\",\"expires_in\":3600,\"refresh_token\":\"AQDrUyIi3u5fqtZfRv-tPQoNxTzLX2NpNsCLb0NRk5ZJ_4HjyG-eDxBto37mar2-SOZUIxoFmD0jLHmCBYHFyqHF9C-PDhukRuEZcJhDRv58Ax7k-u_GCmE2I4xHTnzSk80\",\"scope\":\"playlist-modify-private playlist-modify-public user-read-playback-state user-top-read\"}" string


        return response;
    }
    */

    public string GetUserAuthorizedToken_UsingRefreshToken()
    {
        string? refreshToken = "AQDrUyIi3u5fqtZfRv-tPQoNxTzLX2NpNsCLb0NRk5ZJ_4HjyG-eDxBto37mar2-SOZUIxoFmD0jLHmCBYHFyqHF9C-PDhukRuEZcJhDRv58Ax7k-u_GCmE2I4xHTnzSk80";

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
