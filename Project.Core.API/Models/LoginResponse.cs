namespace Project.Core.API.Models;

public record LoginResponse(string AccessToken, string TokenType, int ExpiresIn);

