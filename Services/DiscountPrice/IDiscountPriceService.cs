using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.DiscountPrice;
namespace MenShopBlazor.Services.DiscountPrice
{
    public interface IDiscountPriceService
    {
        Task<List<DiscountPriceViewModel>> GetAllDiscountPrice();
        Task<DiscountPriceViewModel> GetDiscountPriceById(int id);
        Task<DiscountPriceDetailViewModel> GetDiscountPriceDetailById(int id);
        Task<List<DiscountPriceDetailViewModel>> GetAllProductDetailDiscountPrice(int id);

        Task<DiscountPriceResponse?> CreateDiscountPrice(CreateDiscountPriceDTO dto);
        Task<DiscountPriceDetailResponse> CreateDiscountPriceDetail(CreateDiscountPriceDetailDTO dto);
        Task<ApiResponseModel<object>> UpdateDiscountPrice(int id, CreateDiscountPriceDTO dto);
        Task<ApiResponseModel<object>> UpdateDiscountPriceDetail(int detailId, UpdateDiscountPriceDTO dto);
        Task<ApiResponseModel<object>> DeleteDiscountPriceAsync(int productId);
        Task<ApiResponseModel<object>> DeleteDiscountPriceDetailAsync(int id);
        Task<ApiResponseModel<object>> ToggleDiscountStatusAsync(int discountId);
    }

}
