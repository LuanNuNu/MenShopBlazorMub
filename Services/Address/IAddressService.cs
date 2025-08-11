using static MenShopBlazor.DTOs.AddressDTO.AddressDTO;

namespace MenShopBlazor.Services.Address
{
    public interface IAddressService
    {
        Task<List<ProvinceDTO>> GetProvincesAsync();
        Task<List<DistrictDTO>> GetDistrictsByProvinceAsync(int provinceId);
        Task<List<WardDTO>> GetWardsByDistrictAsync(int districtId);
    }
}
