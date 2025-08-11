using MenShopBlazor.Services.Admin;
using MenShopBlazor.Services.Branch;

namespace MenShopBlazor.Shared
{
    public class BranchHelper
    {
        private readonly IBranchService _branchService;
        private readonly IAdminService _adminService;

        public BranchHelper(IBranchService branchService, IAdminService adminService)
        {
            _branchService = branchService;
            _adminService = adminService;
        }

        public async Task<int?> GetBranchIdAsync(string? role)
        {
            if (string.IsNullOrEmpty(role) || role == "Customer")
            {
                var branches = await _branchService.GetAllBranchesAsync();
                var onlineBranch = branches?.Data?.FirstOrDefault(b => b.IsOnline);
                if (onlineBranch != null)
                    return onlineBranch.BranchId;
            }
            else
            {
                var userResponse = await _adminService.GetCurrentUserAsync();
                var user = userResponse?.Data;
                if (user?.BranchId != null)
                    return user.BranchId;
            }

            return null;
        }
    }

}
