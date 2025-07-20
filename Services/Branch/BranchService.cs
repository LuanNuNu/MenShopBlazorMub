using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Branch;
using MenShopBlazor.DTOs.Fabric;
using MenShopBlazor.DTOs.Product.ViewModel;
using MenShopBlazor.Services.Token;
using MenShopBlazor.Shared;
using System.Net.Http.Json;

namespace MenShopBlazor.Services.Branch
{
    public class BranchService : IBranchService
    {
        private readonly HttpClient _httpClient;
        private const string baseUrl = "https://localhost:7094/api/Branch";
        private readonly ITokenService _tokenService;

        public BranchService(IHttpClientFactory httpClientFactory, ITokenService tokenService)
        {
            _httpClient = httpClientFactory.CreateClient("AuthorizedClient");
            _tokenService = tokenService;
        }
        public async Task<ApiResponseModel<List<BranchViewModel>>> GetAllBranchesAsync()
        {
            var response = await HttpHelper.SendRequestAsync<List<BranchViewModel>>(() =>
                _httpClient.GetAsync($"{baseUrl}/getbranches")
            );

            return response!;
        }

        public async Task<ApiResponseModel<BranchViewModel>> GetBranchByIdAsync(int id)
        {
            var response = await HttpHelper.SendRequestAsync<BranchViewModel>(() =>
                _httpClient.GetAsync($"{baseUrl}/getbranch/{id}")
            );

            return response!;
        }

        public async Task<ApiResponseModel<List<ProductViewModel>>> SearchProductInBranchAsync(int branchId, string searchTerm)
        {
            var response = await HttpHelper.SendRequestAsync<List<ProductViewModel>>(() =>
                _httpClient.GetAsync($"{baseUrl}/{branchId}/search?searchTerm={Uri.EscapeDataString(searchTerm)}")
            );

            return response!;
        }

        public async Task<ApiResponseModel<BranchViewModel>> CreateBranchAsync(CreateUpdateBranchDTO dto)
        {
            var response = await HttpHelper.SendRequestAsync<BranchViewModel>(() =>
                _httpClient.PostAsJsonAsync($"{baseUrl}/create", dto)
            );

            return response!;
        }

        public async Task<ApiResponseModel<BranchViewModel>> UpdateBranchAsync(int branchId,CreateUpdateBranchDTO dto)
        {
            var response = await HttpHelper.SendRequestAsync<BranchViewModel>(() =>
                _httpClient.PutAsJsonAsync($"{baseUrl}/{branchId}", dto)
            );

            return response!;
        }
        public async Task<ApiResponseModel<List<BranchProductModel>>> GetBranchProduct(int? branchId, int? categoryId = null)
        {

            var queryParams = new List<string>();

            if (branchId.HasValue && branchId > 0)
                queryParams.Add($"branchId={branchId.Value}");


            if (categoryId.HasValue && categoryId > 0)
                queryParams.Add($"categoryId={categoryId.Value}");

            string queryString = queryParams.Any()
                ? "?" + string.Join("&", queryParams)
                : "";

            string url = $"{baseUrl}/products{queryString}";

            return await HttpHelper.SendRequestAsync<List<BranchProductModel>>(() =>
                _httpClient.GetAsync(url)
            );
        }




        public async Task<ApiResponseModel<List<BranchProductDetailModel>>> GetBranchProductDetail(int? branchId, int productId)
        {
            string query = branchId.HasValue ? $"?branchId={branchId}" : "";

            return await HttpHelper.SendRequestAsync<List<BranchProductDetailModel>>(() =>
                _httpClient.GetAsync($"{baseUrl}/products/{productId}{query}")
            );
        }
        public async Task<ApiResponseModel<object>> DeleteBranchlAsync(int branchId)
        {
            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.DeleteAsync($"{baseUrl}/delete/{branchId}")
            );
        }
    }
}
