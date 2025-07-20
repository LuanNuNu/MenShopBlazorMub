using MenShopBlazor.Services.Token;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace MenShopBlazor.Services.Auth { 
    public class CustomAuthProvider : AuthenticationStateProvider
    {
        private readonly ITokenService _tokenService;

        public CustomAuthProvider(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var tokenInfo = await _tokenService.GetTokenInfoAsync();

            ClaimsIdentity identity;

            if (!string.IsNullOrEmpty(tokenInfo.UserName))
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, tokenInfo.UserName),
                    new Claim(ClaimTypes.Role, tokenInfo.Role ?? ""),
                    new Claim("userId", tokenInfo.UserId ?? "")
                }, "apiauth_type");
            }
            else
            {
                identity = new ClaimsIdentity();
            }

            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }

        public void MarkUserAsAuthenticated(string userName, string role, string? userId = null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, role)
            };

            if (!string.IsNullOrEmpty(userId))
            {
                claims.Add(new Claim("userId", userId));
            }

            var identity = new ClaimsIdentity(claims, "apiauth_type");
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void MarkUserAsLoggedOut()
        {
            var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
        }
    }
}
