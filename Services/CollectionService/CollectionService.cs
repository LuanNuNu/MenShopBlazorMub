using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Collection;
using MenShopBlazor.DTOs.Collection.CreateandUpdate;
using MenShopBlazor.DTOs.Collection.ViewModel;
using MenShopBlazor.DTOs.Product.ReponseDTO;
using MenShopBlazor.DTOs.Product.ViewModel;
using MenShopBlazor.Services.Collection;
using MenShopBlazor.Shared;
using Newtonsoft.Json;
using System.Text;

namespace MenShopBlazor.Services.CollectionService
{
    public class CollectionService : ICollectionService
    {
        private readonly HttpClient _httpClient;
        private const string baseUrl = "https://localhost:7094/api/Collection";

        public CollectionService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AuthorizedClient");
        }
        public async Task<ApiResponseModel<object>> AddCollection(CollectionCreateDTO dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PostAsync($"{baseUrl}/CreateCollection", content)
            );
        }

        public async Task<ApiResponseModel<object>> UpdateCollection(int id, CollectionCreateDTO dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PutAsync($"{baseUrl}/update-collection/{id}", content)
            );
        }

        public async Task<ApiResponseModel<object>> DeleteCollection(int id)
        {
            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.DeleteAsync($"{baseUrl}/delete-collection/{id}")
            );
        }

        public async Task<ApiResponseModel<List<CollectionViewModel>>> GetAllCollections()
        {

            return await HttpHelper.SendRequestAsync<List<CollectionViewModel>>(() =>
                _httpClient.GetAsync(baseUrl)
            );
        }
        public async Task<ApiResponseModel<CollectionViewModel>> GetCurrentCollection()
        {
            return await HttpHelper.SendRequestAsync<CollectionViewModel>(() =>
                _httpClient.GetAsync($"{baseUrl}/get-current-collection")
            );
        }
        public async Task<ApiResponseModel<CollectionViewModel>> GetCollectionById(int id)
        {
            return await HttpHelper.SendRequestAsync<CollectionViewModel>(() =>
                _httpClient.GetAsync($"{baseUrl}/{id}")
            );
        }

        public async Task<ApiResponseModel<List<CollectionDetailsViewModel>>> GetCollectionDetails(int collectionId)
        {
            return await HttpHelper.SendRequestAsync<List<CollectionDetailsViewModel>>(() =>
                _httpClient.GetAsync($"{baseUrl}/{collectionId}/details")
            );
        }

        public async Task<ApiResponseModel<object>> AddCollectionDetail(CollectionDetailCreateDTO dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PostAsync($"{baseUrl}/add-details", content)
            );
        }

        public async Task<ApiResponseModel<object>> UpdateCollectionDetail(int detailId, CollectionDetailCreateDTO dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PutAsync($"{baseUrl}/details/{detailId}", content)
            );
        }

        public async Task<ApiResponseModel<object>> DeleteCollectionDetail(int detailId)
        {
            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.DeleteAsync($"{baseUrl}/details/{detailId}")
            );
        }

        public async Task<ApiResponseModel<object>> UpdateStatus(int id)
        {
            var content = new StringContent("", Encoding.UTF8, "application/json");

            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PutAsync($"{baseUrl}/{id}/status", content)
            );
        }

        public async Task<List<CreateImageResponse>> AddImagesCollectionAsync(int collectionId, List<string> imageUrls)
        {
            try
            {
                var json = JsonConvert.SerializeObject(imageUrls);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{baseUrl}/add-images/{collectionId}", content);
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<CreateImageResponse>>(result)
               ?? new List<CreateImageResponse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi thêm ảnh chi tiết: {ex.Message}");
                return new List<CreateImageResponse>
                {
                    new CreateImageResponse { IsSuccess = false, Message = ex.Message }
                };
            }
        }

        public async Task<ApiResponseModel<object>> DeleteImageCollectionAsync(int imageId)
        {
            return await HttpHelper.SendRequestAsync<object>(() =>
                 _httpClient.DeleteAsync($"{baseUrl}/collection/images//{imageId}")
            );

        }

        public async Task<IEnumerable<ImageCollectionViewModel>> GetImageCollectonAsync(int collectionId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{baseUrl}/collection/get-images/{collectionId}");
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ImageCollectionViewModel>>(json) ?? new();
            }
            catch (Exception ex)
            {
                return new List<ImageCollectionViewModel>();
            }
        }
    }
}
