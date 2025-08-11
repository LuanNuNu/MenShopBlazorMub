using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Cart;
using MenShopBlazor.DTOs.Product.ViewModel;
using MenShopBlazor.Services.Token;
using MenShopBlazor.Shared;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;

namespace MenShopBlazor.Services.Cart
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;
        private const string baseUrl = "https://localhost:7094/api/Cart";

        public CartService(IHttpClientFactory httpClientFactory, ITokenService tokenService)
        {
            _httpClient = httpClientFactory.CreateClient("AuthorizedClient");
            _tokenService = tokenService;
        }

        public async Task<ApiResponseModel<CartViewModel>> GetCartAsync(string? customerId, string? anonymousId)
        {
            var queryParams = new List<string>();
    
            if (!string.IsNullOrEmpty(customerId))
                queryParams.Add($"customerId={customerId}");
            else if (!string.IsNullOrEmpty(anonymousId))
                queryParams.Add($"anonymousId={anonymousId}");


            var queryString = string.Join("&", queryParams);
            var url = $"{baseUrl}/getcart?{queryString}";
            Console.WriteLine("URL gọi API getcart: " + url);
            var response = await HttpHelper.SendRequestAsync<CartViewModel>(() =>
                _httpClient.GetAsync(url)
            );
            return response!;
        }

        public async Task<ApiResponseModel<object>> AddToCartAsync(CartActionDTO dto)
        {
            var response = await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PostAsJsonAsync($"{baseUrl}/add", dto)
            );
            return response!;
        }

        public async Task<ApiResponseModel<object>> UpdateQuantityAsync(CartActionDTO dto)
        {
            var response = await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PutAsJsonAsync($"{baseUrl}/update", dto)
            );
            return response!;
        }

        public async Task<ApiResponseModel<object>> RemoveFromCartAsync(CartActionDTO dto)
        {
            var response = await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, $"{baseUrl}/remove")
                {
                    Content = JsonContent.Create(dto)
                })
            );
            return response!;
        }

        public async Task<ApiResponseModel<object>> MergeCartAsync(MergeCartRequestDTO request)
        {
            var response = await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PostAsJsonAsync($"{baseUrl}/merge-cart", request)
            );
            return response!;
        }

    }
}
