using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Product.ViewModel;
using MenShopBlazor.DTOs.Receipt.InputReceipt;
using MenShopBlazor.DTOs.Receipt.CreateReceipt;

namespace MenShopBlazor.Services.InputReceiptService
{
    public interface IInputReceiptService
    {
        Task<ApiResponseModel<List<InputReceiptDTO>>> GetAllInputReceiptsAsync();
        Task<ApiResponseModel<List<ProductDetailViewModel>>> GetInputReceiptByIdAsync(int idinput);
        Task<ApiResponseModel<object>> CreateReceiptAsync(List<CreateReceiptDetailDTO> detailDTOs, string managerId);
        Task<ApiResponseModel<object>> CancelReceiptAsync(int id);
        Task<ApiResponseModel<object>> ConfirmReceiptAsync(int id);
    }
}
