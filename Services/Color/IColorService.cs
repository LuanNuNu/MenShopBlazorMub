using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Color;

namespace MenShopBlazor.Services.Color
{
    public interface IColorService
    {
        Task<List<ColorDTO>> GetColorDtos();
        Task<ColorDTO> GetColorId(int id);
        Task<ApiResponseModel<object>> AddColor(ColorDTO colorDto);
        Task<ApiResponseModel<object>> UpdateColor(ColorDTO colorDto);
        Task<ApiResponseModel<object>> DeleteColor(int id);
    }
}
