using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Product.ViewModel;
using MenShopBlazor.DTOs.Receipt.CreateReceipt;
using MenShopBlazor.DTOs.Receipt.InputReceipt;
using MenShopBlazor.Services.Token;
using MenShopBlazor.Shared;
using System.Net.Http;
using System.Net.Http.Json;

namespace MenShopBlazor.Services.InputReceiptService
{
    public class InputReceiptService : IInputReceiptService
    {
        private readonly HttpClient _httpClient;
        private const string baseUrl = "https://localhost:7094/api/InputReceipt";
        private readonly ITokenService _tokenService;

        public InputReceiptService(IHttpClientFactory httpClientFactory, ITokenService tokenService)
        {
            _httpClient = httpClientFactory.CreateClient("AuthorizedClient");
            _tokenService = tokenService;
        }

        public async Task<ApiResponseModel<List<InputReceiptDTO>>> GetAllInputReceiptsAsync()
        {
            return await HttpHelper.SendRequestAsync<List<InputReceiptDTO>>(
                () => _httpClient.GetAsync($"{baseUrl}")
            );
        }

        public async Task<ApiResponseModel<List<ProductDetailViewModel>>> GetInputReceiptByIdAsync(int idinput)
        {
            return await HttpHelper.SendRequestAsync<List<ProductDetailViewModel>>(
                () => _httpClient.GetAsync($"{baseUrl}/{idinput}")
            );
        }

        public async Task<ApiResponseModel<object>> CreateReceiptAsync(
            List<CreateReceiptDetailDTO> detailDTOs,
            string managerId)
        {
            var url = $"{baseUrl}/create?ManagerId={Uri.EscapeDataString(managerId)}";

            return await HttpHelper.SendRequestAsync<object>(
                () => _httpClient.PostAsJsonAsync(url, detailDTOs)
            );
        }

        public async Task<ApiResponseModel<object>> CancelReceiptAsync(int id)
        {
            return await HttpHelper.SendRequestAsync<object>(
                () => _httpClient.PutAsync($"{baseUrl}/cancel/{id}", null)
            );
        }

        public async Task<ApiResponseModel<object>> ConfirmReceiptAsync(int id)
        {
            return await HttpHelper.SendRequestAsync<object>(
                () => _httpClient.PutAsync($"{baseUrl}/confirm/{id}", null)
            );
        }
    }
}
