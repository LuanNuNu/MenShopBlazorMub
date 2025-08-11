using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Cart;

namespace MenShopBlazor.Services.Cart
{
    public interface ICartService
    {
        Task<ApiResponseModel<CartViewModel>> GetCartAsync(string? customerId, string? anonymousId);
        Task<ApiResponseModel<object>> AddToCartAsync(CartActionDTO dto);
        Task<ApiResponseModel<object>> UpdateQuantityAsync(CartActionDTO dto);
        Task<ApiResponseModel<object>> RemoveFromCartAsync(CartActionDTO dto);
        Task<ApiResponseModel<object>> MergeCartAsync(MergeCartRequestDTO request);
    }
}
