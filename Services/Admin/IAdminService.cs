using MenShopBlazor.DTOs.Account;
using MenShopBlazor.DTOs;


namespace MenShopBlazor.Services.Admin
{
    public interface IAdminService
    {
        Task<ApiResponseModel<object>> CreateUserAsync(AccountRegisterDTO model);
        Task<ApiResponseModel<UserViewModel>> GetCurrentUserAsync();
        Task<ApiResponseModel<IEnumerable<UserViewModel>>> GetUsersAsync(string? userId = null, string? email = null, string? roleId = null, int? branchId = null);
        Task<ApiResponseModel<object>> UpdateOwnProfileAsync(CustomerUpdateDTO model);
        Task<ApiResponseModel<object>> UpdateCustomerAsync(string id, CustomerUpdateDTO model);
        Task<ApiResponseModel<object>> UpdateEmployeeAsync(string id, EmployeeUpdateDTO model);
        Task<ApiResponseModel<object>> AddClaimAsync(string userId, string claimType, string claimValue);
        Task<ApiResponseModel<object>> ToggleUserStatusAsync(string userID);
        Task<ApiResponseModel<List<RoleDTO>>> GetRolesAsync();
    }
}
