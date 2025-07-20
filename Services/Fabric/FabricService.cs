using MenShopBlazor.DTOs.Fabric;
using MenShopBlazor.DTOs;
using MenShopBlazor.Services.Fabric;
using System.Text;
using Newtonsoft.Json;
using MenShopBlazor.Shared;

namespace MenShopUI.Services.Fabric
{
    public class FabricService : IFabricService
    {
        private readonly HttpClient _httpClient;
        private const string baseUrl = "https://localhost:7094/api/Fabric";

        public FabricService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AuthorizedClient");
        }

        public async Task<List<FabricDTO>> GetFabricDtos()
        {
            var result = await HttpHelper.SendRequestAsync<List<FabricDTO>>(() =>
                _httpClient.GetAsync(baseUrl)
            );

            return result.Data ?? new List<FabricDTO>();
        }

        public async Task<FabricDTO> GetFadricId(int id)
        {
            var result = await HttpHelper.SendRequestAsync<FabricDTO>(() =>
                _httpClient.GetAsync($"{baseUrl}/{id}")
            );

            return result.Data ?? new FabricDTO();
        }

        public async Task<ApiResponseModel<object>> AddFabric(FabricDTO fabricDto)
        {
            var json = JsonConvert.SerializeObject(fabricDto.Name);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PostAsync(baseUrl, content)
            );
        }

        public async Task<ApiResponseModel<object>> UpdateFabric(FabricDTO fabricDto)
        {
            var json = JsonConvert.SerializeObject(fabricDto.Name);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PutAsync($"{baseUrl}/{fabricDto.FabricId}", content)
            );
        }

        public async Task<ApiResponseModel<object>> DeleteFabric(int id)
        {
            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.DeleteAsync($"{baseUrl}/{id}")
            );
        }
    }
}
