using MenShopBlazor.DTOs.Color;
using MenShopBlazor.DTOs;
using MenShopBlazor.Services.Color;
using Newtonsoft.Json;
using System.Text;
using MenShopBlazor.Shared;

namespace MenShopUI.Services.Color
{
    public class ColorService : IColorService
    {
        private readonly HttpClient _httpClient;
        private const string baseUrl = "https://localhost:7094/api/Color";

        public ColorService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AuthorizedClient");
        }

        public async Task<List<ColorDTO>> GetColorDtos()
        {
            var result = await HttpHelper.SendRequestAsync<List<ColorDTO>>(() =>
                _httpClient.GetAsync($"{baseUrl}")
            );

            return result.Data ?? new List<ColorDTO>();
        }

        public async Task<ColorDTO> GetColorId(int id)
        {
            var result = await HttpHelper.SendRequestAsync<ColorDTO>(() =>
                _httpClient.GetAsync($"{baseUrl}/{id}")
            );

            return result.Data ?? new ColorDTO();
        }

        public async Task<ApiResponseModel<object>> AddColor(ColorDTO colorDto)
        {
            var json = JsonConvert.SerializeObject(colorDto.Name);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PostAsync($"{baseUrl}", content)
            );
        }

        public async Task<ApiResponseModel<object>> UpdateColor(ColorDTO colorDto)
        {
            var json = JsonConvert.SerializeObject(colorDto.Name);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PutAsync($"{baseUrl}/{colorDto.ColorId}", content)
            );
        }

        public async Task<ApiResponseModel<object>> DeleteColor(int id)
        {
            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.DeleteAsync($"{baseUrl}/{id}")
            );
        }
    }
}
