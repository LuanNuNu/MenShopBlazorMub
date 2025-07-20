using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Size;

namespace MenShopBlazor.Services.Size
{
    public interface ISizeService
    {
        Task<List<SizeDTO>> GetSizeAsync();
        Task<SizeDTO> GetSizeById(int id);
        Task<ApiResponseModel<object>> AddSize(SizeDTO sizeDto);
        Task<ApiResponseModel<object>> UpdateSize(SizeDTO sizeDto);
        Task<ApiResponseModel<object>> DeleteSize(int id);
    }
}
