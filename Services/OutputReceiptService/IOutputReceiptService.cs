using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Product.ViewModel;
using MenShopBlazor.DTOs.Receipt.CreateReceipt;
using MenShopBlazor.DTOs.Receipt.OutputReceipt;

namespace MenShopBlazor.Services.OutputReceiptService
{
    public interface IOutputReceiptService
    {
        Task<ApiResponseModel<object>> CancelReceiptAsync(int id);
        Task<ApiResponseModel<object>> ConfirmReceiptAsync(int id);
        Task<ApiResponseModel<object>> CreateReceiptAsync(
                    List<CreateReceiptDetailDTO> detailDTOs,
                    string managerId,
                    int? branchId);
        Task<List<OutputReceiptDTO>?> GetAllOutputReceiptsAsync();
        Task<List<OutputReceiptDTO>?> GetOuputBranch(int branchId);
        Task<List<ProductDetailViewModel>?> GetOutputDetailReceiptDTOs(int idoutput);
    }
}
