using MenShopBlazor.DTOs.Token;

namespace MenShopBlazor.Services.Token
{
    public interface ITokenService
    {
        Task<string?> GetTokenAsync();
        Task SetTokenAsync(string token);
        Task RemoveTokenAsync();
        Task<string?> GetUserIdAsync();
        Task<string?> GetUserNameAsync();
        Task<string?> GetRoleAsync();
        Task<TokenInfo> GetTokenInfoAsync();
        string? GetClaimFromToken(string token, string claimType);
    }
}
