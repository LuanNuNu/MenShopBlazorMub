using MenShopBlazor.Services.Account;
using MenShopBlazor.Services.Token;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace MenShopBlazor.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly CustomAuthProvider _authProvider;

        public AuthService(ITokenService tokenService, AuthenticationStateProvider provider)
        {
            _tokenService = tokenService;
            _authProvider = (CustomAuthProvider)provider;
        }

        public async Task SetAuthenticatedUserAsync(string token)
        {
            await _tokenService.SetTokenAsync(token);
            var info = await _tokenService.GetTokenInfoAsync();
            _authProvider.MarkUserAsAuthenticated(info.UserName, info.Role, info.UserId);
        }


        public async Task LogoutAsync()
        {
            await _tokenService.RemoveTokenAsync();
            _authProvider.MarkUserAsLoggedOut();
        }
    }
}
