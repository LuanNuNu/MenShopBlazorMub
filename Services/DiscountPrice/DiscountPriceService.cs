using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.AddressDTO;
using MenShopBlazor.DTOs.DiscountPrice;
using MenShopBlazor.DTOs.Fabric;
using MenShopBlazor.DTOs.Product.ReponseDTO;
using MenShopBlazor.DTOs.Product.ViewModel;
using MenShopBlazor.Shared;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MenShopBlazor.Services.DiscountPrice
{
    public class DiscountPriceService : IDiscountPriceService
    {
        private readonly HttpClient _httpClient;
        private const string baseUrl = "https://localhost:7094/api/DiscountPrice";

        public DiscountPriceService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AuthorizedClient");
        }
        public async Task<List<DiscountPriceViewModel>> GetAllDiscountPrice()
        {
            try
            {
                var response = await _httpClient.GetAsync(baseUrl);
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DiscountPriceViewModel>>(json) ?? new();
            }
            catch (Exception ex)
            {
                return new List<DiscountPriceViewModel>();
            }
        }


        public async Task<DiscountPriceViewModel> GetDiscountPriceById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{baseUrl}/{id}");
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DiscountPriceViewModel>(json) ?? new();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<DiscountPriceDetailViewModel> GetDiscountPriceDetailById(int id)
        {
                var result = await HttpHelper.SendRequestAsync<DiscountPriceDetailViewModel>(() =>
                    _httpClient.GetAsync($"{baseUrl}/detail/product/{id}")
                );

            return result.Data ?? new DiscountPriceDetailViewModel();
        }




        public async Task<List<DiscountPriceDetailViewModel>> GetAllProductDetailDiscountPrice(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{baseUrl}/detail/{id}");
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DiscountPriceDetailViewModel>>(json) ?? new();
            }
            catch (Exception ex)
            {
                return new List<DiscountPriceDetailViewModel>();
            }
        }




        public async Task<DiscountPriceResponse?> CreateDiscountPrice(CreateDiscountPriceDTO dto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var result = await HttpHelper.SendRequestAsync<DiscountPriceResponse>(
                () => _httpClient.PostAsync(baseUrl, content)
            );
            return result.Data ?? new DiscountPriceResponse
            {
                IsSuccess = false,
                Message = "Không thể tạo chương trình khuyến mãi"
            };
        }

        public async Task<DiscountPriceDetailResponse> CreateDiscountPriceDetail(CreateDiscountPriceDetailDTO dto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

            var rawResponse = await _httpClient.PostAsync($"{baseUrl}/detail", content);
            var json = await rawResponse.Content.ReadAsStringAsync();

            if (rawResponse.StatusCode == System.Net.HttpStatusCode.MultiStatus)
            {
                return new DiscountPriceDetailResponse
                {
                    Results = new List<ProductResult>
                {
                    new()
                    {
                        IsSuccess = false,
                        Message = $"Một số sản phẩm đã có khuyến mãi hoặc bị lỗi khi thêm.\nChi tiết: {json}"
                    }
                }
                };
            }

            if (!rawResponse.IsSuccessStatusCode)
            {
                return new DiscountPriceDetailResponse
                {
                    Results = new List<ProductResult>
                {
                    new()
                    {
                        IsSuccess = false,
                        Message = $"Lỗi: {rawResponse.StatusCode} - {json}"
                    }
                }
                };
            }

            return JsonConvert.DeserializeObject<DiscountPriceDetailResponse>(json) ?? new();
        }

        public async Task<ApiResponseModel<object>> UpdateDiscountPrice(int id, CreateDiscountPriceDTO dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PutAsync($"{baseUrl}/{id}", content)
            );

        }

        public async Task<ApiResponseModel<object>> UpdateDiscountPriceDetail(int detailId, UpdateDiscountPriceDTO dto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            return await HttpHelper.SendRequestAsync<object>(
                () => _httpClient.PutAsync($"{baseUrl}/detail/{detailId}", content)
            );

        }

        public async Task<ApiResponseModel<object>> DeleteDiscountPriceAsync(int productId)
        {
            return await HttpHelper.SendRequestAsync<object>(
                () => _httpClient.DeleteAsync($"{baseUrl}/{productId}")
            );
        }

        public async Task<ApiResponseModel<object>> DeleteDiscountPriceDetailAsync(int id)
        {
            return await HttpHelper.SendRequestAsync<object>(
                () => _httpClient.DeleteAsync($"{baseUrl}/detail/{id}")
            );
        }
        public async Task<ApiResponseModel<object>> ToggleDiscountStatusAsync(int discountId)
        {
            var emptyContent = new StringContent("", Encoding.UTF8, "application/json");
            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PutAsync($"{baseUrl}/updateStatus/{discountId}", emptyContent)
            );
        }

    }

}
