using System.Text;
using Newtonsoft.Json;
using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Account;
using MenShopBlazor.Shared;
using Blazored.SessionStorage;
using System.Net.Http;
using MenShopBlazor.Services.Token;
using MenShopBlazor.Services.Auth;

namespace MenShopBlazor.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;
        private readonly IAuthService _authService;
        private const string baseApiUrl = "https://localhost:7094/api/Account";

        public AccountService(IHttpClientFactory httpClientFactory, ITokenService tokenService, IAuthService authService)
        {
            _httpClient = httpClientFactory.CreateClient("AuthorizedClient");
            _tokenService = tokenService;
            _authService = authService;
        }

        public async Task<ApiResponseModel<LoginResponseDTO>> LoginAsync(AccountLoginDTO model)
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await HttpHelper.SendRequestAsync<LoginResponseDTO>(() =>
                _httpClient.PostAsync($"{baseApiUrl}/login", content)
            );

            if (response.IsSuccess && !string.IsNullOrEmpty(response.Data?.Token))
            {
                await _tokenService.SetTokenAsync(response.Data.Token);
                await _authService.SetAuthenticatedUserAsync(response.Data.Token);
            }

            return response;
        }

        public async Task LogoutAsync()
        {
            await _tokenService.RemoveTokenAsync();
        }

        public async Task<ApiResponseModel<object>> RegisterAsync(AccountRegisterDTO model)
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PostAsync($"{baseApiUrl}/register", content)
            );
        }
    }
}
