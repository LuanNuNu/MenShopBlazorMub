using MenShopBlazor.DTOs.Size;
using MenShopBlazor.DTOs;
using MenShopBlazor.Services.Size;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using MenShopBlazor.Shared;

namespace MenShopUI.Services.Size
{
    public class SizeService : ISizeService
    {
        private readonly HttpClient _httpClient;
        private const string baseUrl = "https://localhost:7094/api/Size";

        public SizeService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AuthorizedClient");
        }

        public async Task<List<SizeDTO>> GetSizeAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponseModel<List<SizeDTO>>>($"{baseUrl}");
            return response?.Data ?? new List<SizeDTO>();
        }

        public async Task<SizeDTO> GetSizeById(int id)
        {
            var response = await _httpClient.GetAsync($"{baseUrl}/{id}");
            var result = await response.Content.ReadAsStringAsync();

            var apiResponse = JsonConvert.DeserializeObject<ApiResponseModel<SizeDTO>>(result);

            return apiResponse?.Data ?? new SizeDTO();
        }

        public async Task<ApiResponseModel<object>> AddSize(SizeDTO sizeDto)
        {
            var json = JsonConvert.SerializeObject(sizeDto.Name);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PostAsync(baseUrl, content)
            );
        }

        public async Task<ApiResponseModel<object>> UpdateSize(SizeDTO sizeDto)
        {
            var json = JsonConvert.SerializeObject(sizeDto.Name);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PutAsync($"{baseUrl}/{sizeDto.SizeId}", content)
            );
        }


        public async Task<ApiResponseModel<object>> DeleteSize(int id)
        {
            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.DeleteAsync($"{baseUrl}/{id}")
            );
        }
    }
}
