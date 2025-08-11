using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Product.ViewModel;
using MenShopBlazor.DTOs.Receipt.CreateReceipt;
using MenShopBlazor.DTOs.Receipt.OutputReceipt;
using MenShopBlazor.Services.Token;
using MenShopBlazor.Shared;
using System.Net.Http;
using System.Net.Http.Json;

namespace MenShopBlazor.Services.OutputReceiptService
{
    public class OutputReceiptService : IOutputReceiptService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;
        private const string baseUrl = "https://localhost:7094/api/OutputReceipt";

        public OutputReceiptService(IHttpClientFactory httpClientFactory, ITokenService tokenService)
        {
            _httpClient = httpClientFactory.CreateClient("AuthorizedClient");
            _tokenService = tokenService;
        }

        public async Task<List<OutputReceiptDTO>?> GetAllOutputReceiptsAsync()
        {
            var response = await HttpHelper.SendRequestAsync<List<OutputReceiptDTO>>(
                () => _httpClient.GetAsync(baseUrl)
            );

            return response?.IsSuccess == true ? response.Data : null;
        }

        public async Task<List<ProductDetailViewModel>?> GetOutputDetailReceiptDTOs(int idoutput)
        {
            var response = await HttpHelper.SendRequestAsync<List<ProductDetailViewModel>>(
                () => _httpClient.GetAsync($"{baseUrl}/{idoutput}")
            );

            return response?.IsSuccess == true ? response.Data : null;
        }

        public async Task<List<OutputReceiptDTO>?> GetOuputBranch(int branchId)
        {
            var response = await HttpHelper.SendRequestAsync<List<OutputReceiptDTO>>(
                () => _httpClient.GetAsync($"{baseUrl}/branch/{branchId}")
            );

            return response?.IsSuccess == true ? response.Data : null;
        }

        public async Task<ApiResponseModel<object>> CancelReceiptAsync(int id)
        {
            return await HttpHelper.SendRequestAsync<object>(
                () => _httpClient.PutAsync($"{baseUrl}/cancel/{id}", null)
            );
;
        }

        public async Task<ApiResponseModel<object>> ConfirmReceiptAsync(int id)
        {
            return await HttpHelper.SendRequestAsync<object>(
                () => _httpClient.PutAsync($"{baseUrl}/confirm/{id}", null)
            );
;
        }

        public async Task<ApiResponseModel<object>> CreateReceiptAsync(
            List<CreateReceiptDetailDTO> detailDTOs,
            string managerId,
            int? branchId)
        {
            var query = $"?branchId={branchId}&managerId={Uri.EscapeDataString(managerId)}";
            var url = $"{baseUrl}/create{query}";

            return await HttpHelper.SendRequestAsync<object>(
                () => _httpClient.PostAsJsonAsync(url, detailDTOs)
            );
        }

    }
}
