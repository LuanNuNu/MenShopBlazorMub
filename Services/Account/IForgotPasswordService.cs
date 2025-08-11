using MenShopBlazor.DTOs.Account;

namespace MenShopBlazor.Services.Account
{
    public interface IForgotPasswordService
    {
        Task<ApiResponse<SessionResponse>> SendOtpAsync(string email);
        Task<ApiResponse<string>> VerifyOtpAsync(string sessionId, string otp);
        Task<ApiResponse<string>> ResetPasswordAsync(string sessionId, string newPassword);
    }
}
