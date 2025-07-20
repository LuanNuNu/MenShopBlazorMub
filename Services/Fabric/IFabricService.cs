using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Fabric;

namespace MenShopBlazor.Services.Fabric
{
    public interface IFabricService
    {
        Task<List<FabricDTO>> GetFabricDtos();
        Task<FabricDTO> GetFadricId(int id);
        Task<ApiResponseModel<object>> AddFabric(FabricDTO fabricDto);
        Task<ApiResponseModel<object>> UpdateFabric(FabricDTO fabricDto);
        Task<ApiResponseModel<object>> DeleteFabric(int id);
    }
}
