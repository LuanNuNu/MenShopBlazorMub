using System.Net.Http.Json;
using MenShopBlazor.DTOs.Account;

namespace MenShopBlazor.Services.Account
{
    public class ForgotPasswordService : IForgotPasswordService
    {
        private readonly HttpClient _http;
        private const string baseApiUrl = "https://localhost:7094/api/ForgotPassword";

        public ForgotPasswordService(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient("AuthorizedClient");
        }

        public async Task<ApiResponse<SessionResponse>> SendOtpAsync(string email)
        {
            var response = await _http.PostAsJsonAsync($"{baseApiUrl}/send-otp", email);
            return await response.Content.ReadFromJsonAsync<ApiResponse<SessionResponse>>();
        }

        public async Task<ApiResponse<string>> VerifyOtpAsync(string sessionId, string otp)
        {
            var body = new { SessionId = sessionId, Otp = otp };
            var response = await _http.PostAsJsonAsync($"{baseApiUrl}/verify-otp", body);
            return await response.Content.ReadFromJsonAsync<ApiResponse<string>>();
        }

        public async Task<ApiResponse<string>> ResetPasswordAsync(string sessionId, string newPassword)
        {
            var body = new { SessionId = sessionId, NewPassword = newPassword };
            var response = await _http.PostAsJsonAsync($"{baseApiUrl}/reset-password", body);
            return await response.Content.ReadFromJsonAsync<ApiResponse<string>>();
        }
    }
}
