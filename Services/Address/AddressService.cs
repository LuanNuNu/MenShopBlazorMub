using System.Net.Http.Json;
using static MenShopBlazor.DTOs.AddressDTO.AddressDTO;

namespace MenShopBlazor.Services.Address
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;

        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ProvinceDTO>> GetProvincesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ProvinceDTO>>("https://provinces.open-api.vn/api/p/");
            return response ?? new List<ProvinceDTO>();
        }

        public async Task<List<DistrictDTO>> GetDistrictsByProvinceAsync(int provinceId)
        {
            var response = await _httpClient.GetFromJsonAsync<ProvinceDetailDto>($"https://provinces.open-api.vn/api/p/{provinceId}?depth=2");
            return response?.Districts ?? new List<DistrictDTO>();
        }

        public async Task<List<WardDTO>> GetWardsByDistrictAsync(int districtId)
        {
            var response = await _httpClient.GetFromJsonAsync<DistrictDetailDto>($"https://provinces.open-api.vn/api/d/{districtId}?depth=2");
            return response?.Wards ?? new List<WardDTO>();
        }
    }
}
