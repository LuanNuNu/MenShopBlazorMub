using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Account;

namespace MenShopBlazor.Services.Account
{
    public interface IAccountService
    {
        Task<ApiResponseModel<object>> RegisterAsync(AccountRegisterDTO model);
        Task<ApiResponseModel<LoginResponseDTO>> LoginAsync(AccountLoginDTO model);
        Task LogoutAsync();
    }
}
