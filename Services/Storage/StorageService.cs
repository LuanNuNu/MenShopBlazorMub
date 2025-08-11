using MenShopBlazor.DTOs.Product.ViewModel;
using MenShopBlazor.DTOs.Receipt.InputReceipt;
using MenShopBlazor.DTOs.Storage;
using MenShopBlazor.Services.Token;
using MenShopBlazor.Shared;
using Newtonsoft.Json;

namespace MenShopBlazor.Services.Storage
{
    public class StorageService : IStorageService
    {
        private readonly HttpClient _httpClient;
        private const string baseUrl = "https://localhost:7094/api/Storage";
        private readonly ITokenService _tokenService;
        public StorageService(IHttpClientFactory httpClientFactory, ITokenService tokenService)
        {
            _httpClient = httpClientFactory.CreateClient("AuthorizedClient");
            _tokenService = tokenService;
        }

        public async Task<List<StorageViewModel>?> GetAllProductsStorageAsync()
        {
            try
            {
                var response = await HttpHelper.SendRequestAsync<List<StorageViewModel>>(() => _httpClient.GetAsync($"{baseUrl}"));
                if (response?.IsSuccess == true)
                {
                    return response.Data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi gọi API: " + ex.Message);
            }
            return null;
        }
        public async Task<List<ProductViewModel>> GetByProductId(int storageId)
        {
            try
            {
                var response = await HttpHelper.SendRequestAsync<List<ProductViewModel>>(() => _httpClient.GetAsync($"{baseUrl}/{storageId}/products"));
                if (response?.IsSuccess == true)
                {
                    return response.Data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi gọi API: " + ex.Message);
            }
            return null;
        }
        public async Task<IEnumerable<ProductDetailViewModel>> GetByProductDetailId(int productId)
        {
            try
            {
                var response = await HttpHelper.SendRequestAsync<List<ProductDetailViewModel>>(() => _httpClient.GetAsync($"{baseUrl}/product/{productId}/details"));
                if (response?.IsSuccess == true)
                {
                    return response.Data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi gọi API: " + ex.Message);
            }
            return null;
        }
    }
}