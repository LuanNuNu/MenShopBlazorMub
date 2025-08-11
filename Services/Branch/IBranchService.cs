using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Product.ViewModel;
using MenShopBlazor.DTOs.Branch;

namespace MenShopBlazor.Services.Branch
{
    public interface IBranchService
    {
        Task<ApiResponseModel<List<BranchViewModel>>> GetAllBranchesAsync();
        Task<ApiResponseModel<List<ProductViewModel>>> SearchProductInBranchAsync(int branchId, string searchTerm);
        Task<ApiResponseModel<BranchViewModel>> GetBranchByIdAsync(int id);
        Task<ApiResponseModel<BranchViewModel>> CreateBranchAsync(CreateUpdateBranchDTO dto);
        Task<ApiResponseModel<BranchViewModel>> UpdateBranchAsync(int branchId, CreateUpdateBranchDTO dto);
        Task<ApiResponseModel<List<BranchProductModel>>> GetBranchProduct(int? branchId, int? categoryId = null);
        Task<ApiResponseModel<List<BranchProductDetailModel>>> GetBranchProductDetailbyProductId(int? branchId, int productId);
        Task<ApiResponseModel<BranchProductDetailModel>> GetBranchProductDetailAsync(int branchId, int productDetailId);
        Task<ApiResponseModel<object>> DeleteBranchlAsync(int branchId);

    }
}
