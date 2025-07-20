using Blazored.SessionStorage;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using MenShopBlazor.Services.Token;
using MenShopBlazor.DTOs.Token;
using System.Data;
using MenShopBlazor.Services.Auth;
using Microsoft.AspNetCore.Components.Authorization;


public class TokenService : ITokenService
{
    private readonly ISessionStorageService _sessionStorage;
    private const string TokenKey = "authToken";

    public TokenService(ISessionStorageService sessionStorage)
    {
        _sessionStorage = sessionStorage;
    }

    public async Task<string?> GetTokenAsync()
    {
        return await _sessionStorage.GetItemAsync<string>(TokenKey);
    }

    public async Task SetTokenAsync(string token)
    {
        await _sessionStorage.SetItemAsync(TokenKey, token);
    }
    public async Task<TokenInfo> GetTokenInfoAsync()
    {
        var token = await GetTokenAsync();
        if (string.IsNullOrEmpty(token)) return new TokenInfo();

        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(token);

        return new TokenInfo
        {
            UserId = jwt.Claims.FirstOrDefault(c => c.Type == "nameid")?.Value,
            UserName = jwt.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value,
            Role = jwt.Claims.FirstOrDefault(c => c.Type == "role")?.Value
        };
    }


    public async Task<string?> GetUserIdAsync()
    {
        var token = await GetTokenAsync();
        if (string.IsNullOrEmpty(token)) return null;

        return GetClaimFromToken(token, "nameid");
    }
    public async Task<string?> GetUserNameAsync()
    {
        var token = await GetTokenAsync();
        if (string.IsNullOrEmpty(token)) return null;

        return GetClaimFromToken(token, "unique_name");
    }
    public async Task<string?> GetRoleAsync()
    {
        var token = await GetTokenAsync();
        if (string.IsNullOrEmpty(token)) return null;

        return GetClaimFromToken(token, "role");
    }
    public async Task RemoveTokenAsync()
    {
        await _sessionStorage.RemoveItemAsync(TokenKey);
    }

    public string? GetClaimFromToken(string token, string claimType)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(token);
        return jwt.Claims.FirstOrDefault(c => c.Type == claimType)?.Value;
    }
}

